using System.Windows.Controls;

namespace MailLab.Elements
{
    internal class MailTab : TabBase
    {
        public MailTab(TabItem tabItem) : base(tabItem) { }

        public override object Clone() => new MailTab(CloneTabItem());

        public MenuItem CloseTabMenuItem =>
            GetElement(tabItem => (MenuItem)tabItem.ContextMenu.Items[0]);

        public Button SendButton =>
            GetElement(tabItem => (Button)((Grid)((Grid)tabItem.Content).Children[0]).Children[1]);

        public TextBox FromTextBox =>
            GetElement(tabItem => (TextBox)((StackPanel)((Grid)((Grid)tabItem.Content).Children[0]).Children[0]).Children[0]);

        public TextBox ToTextBox =>
            GetElement(tabItem => (TextBox)((StackPanel)((Grid)((Grid)tabItem.Content).Children[0]).Children[0]).Children[1]);

        public TextBox SubjectTextBox =>
            GetElement(tabItem => (TextBox)((StackPanel)((Grid)((Grid)tabItem.Content).Children[0]).Children[0]).Children[2]);
    }
}
