using MailLab.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        private MailTab OriginalMailTab;

        public MainWindow()
        {
            InitializeComponent();

            OriginalMailTab = GetOriginalMailtab();
        }

        private MailTab GetOriginalMailtab()
        {
            var tab = firstTab;
            CloseTabs();
            return new MailTab(tab);
        }

        private void CloseTabs() => mailTabs.Items.Clear();

        private void NewEmail_Click(object sender, RoutedEventArgs e)
        {
            var newMailTab = new MailTab((TabItem)OriginalMailTab.Clone());
            newMailTab.TabItem.Header = "New Email";

            mailTabs.Items.Add(newMailTab.TabItem);
        }

        private void CloseAll_Click(object sender, RoutedEventArgs e)
        {
            CloseTabs();
        }
    }
}
