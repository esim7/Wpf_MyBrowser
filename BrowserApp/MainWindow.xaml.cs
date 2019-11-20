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

namespace BrowserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WebBrowser browser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.browser.GoBack();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.browser.GoForward();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.Items.Count == 0)
            {
                AddPage_Click(sender, e);
            }
            else
            {
                if (textBox_URL.Text.Length > 0)
                {
                    this.browser.Source = new Uri("https://" + textBox_URL.Text);
                }
                else
                {
                    MessageBox.Show("Invalid URL");
                }
            }

        }

        private void AddPage_Click(object sender, RoutedEventArgs e)
        {
            browser = new WebBrowser();
            TabItem tabItem = new TabItem() 
            { 
                Header = "NewPage", 
                Content = browser as WebBrowser
            };
            tabControl.Items.Add(tabItem);
        }
    }
}
