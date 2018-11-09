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

        public LogManagerTab()
        {
            InitializeComponent();

            this.SlvLogs.ItemSelectionChanged += SlvLogs_ItemSelectionChanged;

            RefreshLogs();
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

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshLogs();
        }

        private void RefreshLogs()
        {
            DirectoryInfo logDir = new DirectoryInfo(Fl.Location(RequestFile.Serverdir) + "\\logs\\");

            // Clear list
            SlvLogs.Items.Clear();

            // Load and display logs
            foreach (FileInfo i in logDir.GetFiles())
            {
                if (i.Extension != ".log" && i.Extension != ".gz")
                    continue;

                LogFile f = new LogFile(i);
                CreateItem(f);
            }
        }

        private void CreateItem(LogFile log)
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
            // Size column
            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = string.Format("{0} kb", log.GetSize())
            });

            SlvLogs.Items.Add(item);
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
                        _fileInfo.LastWriteTime.Year,
                        _fileInfo.LastWriteTime.Month,
                        _fileInfo.LastWriteTime.Day);
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

        public long GetSize()
        {
            return _fileInfo.Length == 0 
                ? 0 
                : (_fileInfo.Length % 1024 == 0 
                    ? _fileInfo.Length / 1024 
                    : (_fileInfo.Length / 1024) + 1);
        }
    }
}
