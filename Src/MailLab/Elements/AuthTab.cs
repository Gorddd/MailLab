using System.Windows.Controls;


namespace MailLab.Elements
{
    class AuthTab : TabBase
    {
        public AuthTab(TabItem tabItem) : base(tabItem) { }

        public override object Clone() => new AuthTab(CloneTabItem());

        public MenuItem CloseTabMenuItem =>
            GetElement(tabItem => (MenuItem)tabItem.ContextMenu.Items[0]);
    }
}
