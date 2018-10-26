using System;
using MetroFramework.Controls;
using System.IO;

namespace Net.Bertware.Bukkitgui2.AddOn.LogManager
{
    public partial class LogManagerTab : MetroUserControl, IAddonTab
    {
        public IAddon ParentAddon { get; set; }

        public LogManagerTab()
        {
            InitializeComponent();
            //this.Load += LogManagerTab_Load;
        }

        private void LogManagerTab_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void LoadLogs()
        {
            throw new NotImplementedException();
        }
    }

    internal class LogFile
    {
        public string Filename { get; private set; }

        public LogFile(string filename)
        {
            Filename = filename;
        }

        public string GetName()
        {
            FileInfo info = new FileInfo(Filename);
            return info.Name;
        }

        public string GetDate()
        {
            throw new NotImplementedException();
        }
        
        public string GetText()
        {
            throw new NotImplementedException();
        }
    }
}
