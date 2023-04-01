using MailLab.Elements.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace MailLab.Elements
{
    internal class MailTab : ICloneable, ITab
    {
        public TabItem TabItem { get; }

        public MailTab(TabItem tabItem)
        {
            TabItem = tabItem;
        }

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
                
        private T GetElement<T>(Func<TabItem, T> getFunc)
        {
            try
            {
                return getFunc(TabItem);
            }
            catch (Exception)
            {
                throw new ArgumentException("Error in GetElement function. It seems that tabItem from ctor is not MailTab");
            }
        }

        public object Clone()
        {
            var strMailTab = XamlWriter.Save(TabItem);
            XmlReader xmlMailTab = XmlReader.Create(new StringReader(strMailTab));
            var tabItem = (TabItem)XamlReader.Load(xmlMailTab);

            return new MailTab(tabItem);
        }
    }
}
