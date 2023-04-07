using System;
using System.CodeDom;
using System.IO;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace MailLab.Elements
{
    abstract class TabBase : ICloneable
    {
        public virtual TabItem TabItem { get; }

        protected TabBase(TabItem tabItem)
        {
            TabItem = tabItem;
        }
        
        protected T GetElement<T>(Func<TabItem, T> getFunc)
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

        public abstract object Clone();

        protected TabItem CloneTabItem()
        {
            var strMailTab = XamlWriter.Save(TabItem);
            XmlReader xmlMailTab = XmlReader.Create(new StringReader(strMailTab));
            var tabItem = (TabItem)XamlReader.Load(xmlMailTab);

            return tabItem;
        }
    }
}
