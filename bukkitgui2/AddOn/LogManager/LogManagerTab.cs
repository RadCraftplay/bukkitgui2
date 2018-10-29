using System;
using MetroFramework.Controls;
using System.IO;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using System.Collections.Generic;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core.Util;

namespace Net.Bertware.Bukkitgui2.AddOn.LogManager
{
    public partial class LogManagerTab : MetroUserControl, IAddonTab
    {
        public IAddon ParentAddon { get; set; }

        private List<LogFile> _logs;

        public LogManagerTab()
        {
            InitializeComponent();

            this.Load += LogManagerTab_Load;
            this.SlvLogs.ItemSelectionChanged += SlvLogs_ItemSelectionChanged;

            LoadLogs();
        }

        private void SlvLogs_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item != null && e.IsSelected == true)
            {
                LogFile log = e.Item.Tag as LogFile;
                RtbPreview.Text = log.GetText();
            }
            else
            {
                RtbPreview.Text = null;
            }
        }

        private void LogManagerTab_Load(object sender, EventArgs e)
        {
            foreach (LogFile log in _logs)
            {
                // Name column
                ListViewItem item = new ListViewItem();
                item.Text = log.GetName();
                item.Tag = log;

                // Date column
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = log.GetDate()
                });

                SlvLogs.Items.Add(item);
            }
        }

        private void LoadLogs()
        {
            DirectoryInfo logDir = new DirectoryInfo(Fl.Location(RequestFile.Serverdir) + "\\logs\\");
            _logs = new List<LogFile>();

            foreach (FileInfo i in logDir.GetFiles())
            {
                if (i.Extension != ".log" && i.Extension != ".gz")
                    continue;

                LogFile f = new LogFile(i);
                _logs.Add(f);
            }
        }
    }

    internal class LogFile
    {
        private FileInfo _fileInfo;

        public LogFile(FileInfo info)
        {
            _fileInfo = info;
        }

        public string GetName()
        {
            return _fileInfo.Name;
        }

        public string GetDate()
        {
            string date = string.Empty;

            switch (_fileInfo.Extension)
            {
                case ".gz":
                    // Deserialize date from filename
                    string[] parts = GetName().Split('-');
                    date = string.Format("{0}-{1}-{2}",
                        parts[0],
                        parts[1],
                        parts[2]);
                    break;
                default:
                    date = string.Format("{0}-{1}-{2}",
                        _fileInfo.CreationTime.Year,
                        _fileInfo.CreationTime.Month,
                        _fileInfo.CreationTime.Day);
                    break;
            }

            return date;
        }

        public string GetText()
        {
            string text = string.Empty;

            switch (_fileInfo.Extension)
            {
                case ".gz":
                    text = Compression.GZipDecompressTxtFile(_fileInfo.FullName);
                    break;
                default:
                    using (TextReader r = new StreamReader(_fileInfo.FullName))
                    {
                        text = r.ReadToEnd();
                    }
                    break;
            }

            return text;
        }
    }
}
