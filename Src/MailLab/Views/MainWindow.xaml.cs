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
using ViewModel.ViewModels;

namespace MailLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TabViewHelper tabViewHelper;

        public ConfigViewModel ConfigViewModel { get; }

        public MainWindow(ConfigViewModel configViewModel)
        {
            InitializeComponent();

            tabViewHelper = new TabViewHelper(tabs);

            ConfigViewModel = configViewModel;
        }

        private void NewEmail_Click(object sender, RoutedEventArgs e)
        {
            tabViewHelper.NewEmailTab();
        }

        private async void NewAuth_ClickAsync(object sender, RoutedEventArgs e)
        {
            await tabViewHelper.NewAuthTab(ConfigViewModel);
        }

        private void CloseAll_Click(object sender, RoutedEventArgs e)
        {
            tabViewHelper.CloseAllTabs();
        }
    }
}
