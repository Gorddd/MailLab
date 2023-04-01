using MailLab.Elements;
using MailLab.Elements.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MailLab.Helpers
{
    class TabHelper<T> where T : ICloneable, ITab
    {
        public TabHelper(TabControl tabControl, T originalTabItem)
        {
            TabControl = tabControl;
            OriginalTabItem = originalTabItem;
            CloseTabs();
        }

        public T OriginalTabItem { get; private set; }
        public TabControl TabControl { get; private set; }
        public int CreatedTabsNum { get; private set; } = 0;

        public void CloseTabs()
        {
            TabControl.Items.Clear();
            CreatedTabsNum = 0;
        }

        public void CloseSpecificTab(string tabHeader)
        {
            var tabToRemove = TabControl.Items.Cast<TabItem>().Single(t => t.Header.ToString() == tabHeader);
            TabControl.Items.Remove(tabToRemove);
        }

        public void MakeNewTab(Action<T> makeConfig)
        {
            var newTab = (T)OriginalTabItem.Clone();

            CreatedTabsNum++;
            makeConfig(newTab);

            TabControl.Items.Add(newTab.TabItem);
        }
    }
}
