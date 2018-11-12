using System;
using MetroFramework.Controls;
using System.IO;
using Net.Bertware.Bukkitgui2.Core.FileLocation;
using System.Collections.Generic;
using System.Windows.Forms;
using Net.Bertware.Bukkitgui2.Core.Util;
using System.Diagnostics;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.AddOn.LogManager
{
    public partial class LogManagerTab : MetroUserControl, IAddonTab
    {
        public IAddon ParentAddon { get; set; }

        private static string GetLogsDirectory()
        {
            return Fl.Location(RequestFile.Serverdir) + "logs\\";
        }

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
                RtbPreview.Text = log.Text;
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

        private void BtnOpenDir_Click(object sender, EventArgs e)
        {
            Process explorer = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "explorer.exe",
                    Arguments = '"' + GetLogsDirectory() + '"'
                }
            };
            explorer.Start(); //Open containing directory
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (SlvLogs.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem i in SlvLogs.SelectedItems)
                    {
                        LogFile log = i.Tag as LogFile;
                        File.Delete(log.FileName);
                        i.Remove();
                    }
                }
            }
            catch
            {
                Logger.Log(LogLevel.Warning, this.ToString(), "Error removing selected file(s)");
                MessageBox.Show("Unable to remove selected file(s)!",
                    string.Format("BukkitGUI 2: {0}", ParentAddon.Name),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void RefreshLogs()
        {
            DirectoryInfo logDir = new DirectoryInfo(GetLogsDirectory());

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
            item.Text = log.Name;
            item.Tag = log;

            // Date column
            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = log.Date
            });
            // Size column
            item.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = string.Format("{0} kb", log.Size)
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

        public string Name => _fileInfo.Name;
        public string FileName => _fileInfo.FullName;

        public string Date
        {
            get
            {
                string date = string.Empty;

                switch (_fileInfo.Extension)
                {
                    case ".gz":
                        // Deserialize date from filename
                        string[] parts = Name.Split('-');
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
        }

        public string Text
        {
            get
            {
                string text = string.Empty;

                try
                {
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
                }
                catch (Exception e)
                {
                    text = "Error: " + e.Message;
                }

                return text;
            }
        }

        public long Size
        {
            get
            {
                return _fileInfo.Length == 0
                    ? 0
                    : (_fileInfo.Length % 1024 == 0
                        ? _fileInfo.Length / 1024
                        : (_fileInfo.Length / 1024) + 1);
            }
        }
    }
}
