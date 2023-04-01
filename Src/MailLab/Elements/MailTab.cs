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
    class MailTab : TabItem, ICloneable
    {
        public TabItem TabItem { get; private set; }

        public MailTab(TabItem tabItem)
        {
            TabItem = tabItem;
        }

        public Button SendButton => 
            GetElement(content => (Button)((Grid)((Grid)content).Children[0]).Children[1]);

        public TextBox FromTextBox => 
            GetElement(content => (TextBox)((StackPanel)((Grid)((Grid)content).Children[0]).Children[0]).Children[0]);

        public TextBox ToTextBox =>
            GetElement(content => (TextBox)((StackPanel)((Grid)((Grid)content).Children[0]).Children[0]).Children[1]);

        public TextBox SubjectTextBox => 
            GetElement(content => (TextBox)((StackPanel)((Grid)((Grid)content).Children[0]).Children[0]).Children[2]);
                
        private T GetElement<T>(Func<object, T> getFunc)
        {
            try
            {
                return getFunc(TabItem.Content);
            }
            catch (Exception)
            {
                throw new ArgumentException("Error in GetElement function. It seems that tabItem from ctor is not MailTab");
            }
        }

        public object Clone()
        {
            var mailTab = XamlWriter.Save(TabItem);
            XmlReader xmlMailTab = XmlReader.Create(new StringReader(mailTab));
            return XamlReader.Load(xmlMailTab);
        }
    }
}
