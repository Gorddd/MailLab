using MailLab.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ViewModel;
using ViewModel.Dtos;
using ViewModel.ViewModels;

namespace MailLab.Helpers
{
    class TabViewHelper
    {
        private TabControl tabs;

        private TabHelper<MailTab> mailTabsHelper;
        private TabHelper<AuthTab> authTabsHelper;

        public TabViewHelper(TabControl tabs)
        {
            this.tabs = tabs;

            mailTabsHelper = new TabHelper<MailTab>(tabs, new MailTab((TabItem)tabs.Items[0]));
            authTabsHelper = new TabHelper<AuthTab>(tabs, new AuthTab((TabItem)tabs.Items[1]));

            //mailTabsHelper.CloseTabs("Email");
            authTabsHelper.CloseTabs("Auth");
        }

        public void NewEmailTab()
        {
            mailTabsHelper.MakeNewTab(tab =>
            {
                tab.TabItem.Header = $"{mailTabsHelper.CreatedTabsNum} New Email";
                tab.CloseTabMenuItem.Click += CloseSpecificTab;
            });
        }

        public async Task NewAuthTab(ConfigViewModel configViewModel)
        {
            if (TryGetAuthTab(out TabItem authTab))
            {
                tabs.SelectedItem = authTab;
                return;
            }

            await configViewModel.BuildCollection();
            authTabsHelper.MakeNewTab(tab =>
            {
                tab.TabItem.Header = "Auth";
                tab.CloseTabMenuItem.Click += CloseSpecificTab;
                tab.SaveConfigButton.Click += async (s, e) => await configViewModel.AddUpdateConfig();
                tab.RemoveButton.Click += async (s, e) => await configViewModel.RemoveConfig();
                tab.SingInButton.Click += async (s, e) => await configViewModel.SignIn();
                tab.ConfigsDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Configs") { Source = configViewModel });
                tab.EmailTextBox.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.Email") { Source = tab.ConfigsDataGrid });
                tab.SmtpServerTextBox.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.SmtpServer") { Source = tab.ConfigsDataGrid });
                tab.SmtpPortTextBox.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.SmtpPort") { Source = tab.ConfigsDataGrid });
                tab.ImapServerTextBox.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.ImapServer") { Source = tab.ConfigsDataGrid });
                tab.ImapPortTextBox.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.ImapPort") { Source = tab.ConfigsDataGrid });
                tab.ConfigsDataGrid.SelectionChanged += (s, e) =>
                {
                    configViewModel.SelectedConfig = tab.ConfigsDataGrid.SelectedItem as ConfigDto ?? new ConfigDto();
                    configViewModel.Password = tab.PasswordTextBox.Password;
                };
                tab.PasswordTextBox.PasswordChanged += (s, e) => configViewModel.Password = tab.PasswordTextBox.Password;
                configViewModel.Configs.Add(new ConfigDto());
                tab.ConfigsDataGrid.SelectedItem = configViewModel.Configs.Last();
            });
        }

        public void CloseAllTabs()
        {
            mailTabsHelper.CloseTabs("Email");
            mailTabsHelper.CloseTabs("Auth");
        }

        public void CloseSpecificTab(object sender, RoutedEventArgs e)
        {
            var tabHeader = ((TabItem)((ContextMenu)((MenuItem)e.Source).Parent).PlacementTarget).Header.ToString();
            if (tabHeader != null)
            {
                mailTabsHelper.CloseSpecificTab(tabHeader);
                authTabsHelper.CloseSpecificTab(tabHeader);
            }
        }

        public bool TryGetAuthTab(out TabItem authTab)
        {
            Func<TabItem, bool> isAuthTab = tab => tab.Header.ToString() == "Auth";

            authTab = tabs.Items.Cast<TabItem>().FirstOrDefault(isAuthTab)!;

            return authTab != null;
        }
    }
}
