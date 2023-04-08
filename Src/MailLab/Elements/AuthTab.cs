using System.Windows.Controls;


namespace MailLab.Elements
{
    class AuthTab : TabBase
    {
        public AuthTab(TabItem tabItem) : base(tabItem) { }

        public override object Clone() => new AuthTab(CloneTabItem());

        public MenuItem CloseTabMenuItem =>
            GetElement(tabItem => (MenuItem)tabItem.ContextMenu.Items[0]);

        public DataGrid ConfigsDataGrid =>
            GetElement(tabItem => (DataGrid)((StackPanel)((Grid)tabItem.Content).Children[2]).Children[0]);

        public TextBox EmailTextBox =>
            GetElement(tabItem => (TextBox)((StackPanel)((Grid)tabItem.Content).Children[0]).Children[1]);

        public PasswordBox PasswordTextBox =>
            GetElement(tabItem => (PasswordBox)((StackPanel)((Grid)tabItem.Content).Children[0]).Children[3]);

        public Button SingInButton =>
            GetElement(tabItem => (Button)((StackPanel)((Grid)tabItem.Content).Children[0]).Children[4]);

        public Button SaveConfigButton =>
            GetElement(tabItem => (Button)((StackPanel)((Grid)tabItem.Content).Children[0]).Children[5]);

        public Button RemoveButton =>
            GetElement(tabItem => (Button)((StackPanel)((Grid)tabItem.Content).Children[0]).Children[6]);

        public TextBox SmtpServerTextBox =>
            GetElement(tabItem => (TextBox)((StackPanel)((Grid)tabItem.Content).Children[1]).Children[1]);

        public TextBox SmtpPortTextBox =>
            GetElement(tabItem => (TextBox)((StackPanel)((Grid)tabItem.Content).Children[1]).Children[3]);

        public TextBox ImapServerTextBox =>
            GetElement(tabItem => (TextBox)((StackPanel)((Grid)tabItem.Content).Children[1]).Children[5]);

        public TextBox ImapPortTextBox =>
            GetElement(tabItem => (TextBox)((StackPanel)((Grid)tabItem.Content).Children[1]).Children[7]);
    }
}
