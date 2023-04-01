﻿using MailLab.Elements;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewEmail_Click(object sender, RoutedEventArgs e)
        {
            var newMailTab = new MailTab((TabItem)new MailTab(firstTab).Clone());
            newMailTab.TabItem.Header = "New Email";
            newMailTab.MakeVisible();

            mailTabs.Items.Add(newMailTab.TabItem);
        }
    }
}
