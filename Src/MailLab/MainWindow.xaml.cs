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
using System.Windows.Controls.Ribbon;
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
        private TabHelper<AuthTab> authTabsHelper;

        public MainWindow()
        {
            InitializeComponent();

            mailTabsHelper = new TabHelper<MailTab>(tabs, new MailTab((TabItem)tabs.Items[0]));
            authTabsHelper = new TabHelper<AuthTab>(tabs, new AuthTab((TabItem)tabs.Items[1]));

            mailTabsHelper.CloseTabs("Email");
            authTabsHelper.CloseTabs("Auth");
        }

        private void NewEmail_Click(object sender, RoutedEventArgs e)
        {

            mailTabsHelper.MakeNewTab(tab =>
            {
                tab.TabItem.Header = $"{mailTabsHelper.CreatedTabsNum} New Email";
                tab.CloseTabMenuItem.Click += CloseSpecificTab_Click;
            });
        }

        private void NewAuth_Click(object sender, RoutedEventArgs e)
        {
            Func<TabItem, bool> isAuthTab = tab => tab.Header.ToString() == "Auth";

            var hasAuthTab = tabs.Items.Cast<TabItem>().Any(isAuthTab);
            if (hasAuthTab)
            {
                tabs.SelectedItem = tabs.Items.Cast<TabItem>().Single(isAuthTab);
                return;
            }

            authTabsHelper.MakeNewTab(tab =>
            {
                tab.TabItem.Header = "Auth";
                tab.CloseTabMenuItem.Click += CloseSpecificTab_Click;
            });
        }

        private void CloseAll_Click(object sender, RoutedEventArgs e)
        {
            mailTabsHelper.CloseTabs("Email");
            mailTabsHelper.CloseTabs("Auth");
        }

        private void CloseSpecificTab_Click(object sender, RoutedEventArgs e)
        {
            var tabHeader = ((TabItem)((ContextMenu)((MenuItem)e.Source).Parent).PlacementTarget).Header.ToString();
            if (tabHeader != null)
            {
                mailTabsHelper.CloseSpecificTab(tabHeader);
                authTabsHelper.CloseSpecificTab(tabHeader);
            }
        }
    }
}
