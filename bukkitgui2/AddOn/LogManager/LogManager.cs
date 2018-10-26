using MetroFramework.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn.LogManager
{
    public class LogManager : IAddon
    {
        public string Name { get; private set; }
        public bool HasTab { get; private set; }
        public bool HasConfig { get; private set; }
        public MetroUserControl TabPage { get; private set; }
        public MetroUserControl ConfigPage { get; private set; }

        public LogManager()
        {
            Name = "Log Manager";
            HasTab = true;
            HasConfig = false;
        }

        public void Dispose() { }

        public void Initialize()
        {
            TabPage = new LogManagerTab() { ParentAddon = this };
        }
    }
}
