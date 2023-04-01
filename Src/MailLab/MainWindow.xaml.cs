using MailLab.Elements;
using MailLab.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TabHelper<MailTab> mailTabsHelper;

        public MainWindow()
        {
            InitializeComponent();

            mailTabsHelper = new(mailTabs, new MailTab((TabItem)mailTabs.Items[0]));
        }

        private void NewEmail_Click(object sender, RoutedEventArgs e)
        {
            mailTabsHelper.MakeNewTab(tab =>
            {
                tab.TabItem.Header = $"{mailTabsHelper.CreatedTabsNum} New Email";
                tab.CloseTabMenuItem.Click += CloseSpecificTab_Click;
            });
        }

        private void CloseAll_Click(object sender, RoutedEventArgs e)
        {
            mailTabsHelper.CloseTabs();
        }

        private void CloseSpecificTab_Click(object sender, RoutedEventArgs e)
        {
            var tabHeader = ((TabItem)((ContextMenu)((MenuItem)e.Source).Parent).PlacementTarget).Header.ToString();
            if (tabHeader != null)
                mailTabsHelper.CloseSpecificTab(tabHeader);
        }
    }
}
