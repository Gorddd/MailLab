using MailLab.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MailLab.Helpers
{
    class TabHelper<T> where T : TabBase
    {
        public TabHelper(TabControl tabControl, T originalTabItem)
        {
            TabControl = tabControl;
            OriginalTabItem = originalTabItem;
        }

        public T OriginalTabItem { get; private set; }
        public TabControl TabControl { get; private set; }
        public int CreatedTabsNum { get; private set; } = 0;

        public void CloseTabs(string keyWord)
        {
            TabControl.Items
                .Cast<TabItem>()
                .Where(tab => tab.Header.ToString()?.Contains(keyWord) ?? false)
                .ToList().ForEach(tab => TabControl.Items.Remove(tab));

            CreatedTabsNum = 0;
        }

        public void CloseSpecificTab(string tabHeader)
        {
            var tabToRemove = TabControl.Items.Cast<TabItem>().FirstOrDefault(t => t.Header.ToString() == tabHeader);
            if (tabToRemove != null) 
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
