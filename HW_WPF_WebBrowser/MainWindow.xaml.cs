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

namespace HW_WPF_WebBrowser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            urlTextBox.Text = "https://www.google.kz/";
            webBrowser.Navigate("https://www.google.kz/");
        }

        private string GetUrlFormatted()
        {
            string url = urlTextBox.Text;
            if(!url.Contains("://") && !url.Contains(":\\"))
            {
                url = "https://" + url;
            }
            return url;
        }
        
        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    webBrowser.Source = new Uri(GetUrlFormatted());
                }
                catch (Exception ex)
                {
                    webBrowser.Focus();
                    urlTextBox.Text = webBrowser.Source.ToString();
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                webBrowser.Source = new Uri(GetUrlFormatted());
            }
            catch { urlTextBox.Focus(); }
            
        }
        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (webBrowser.CanGoBack)
            {
                webBrowser.GoBack();
                urlTextBox.Text = "";
                UpdateButton_Click(sender, e);
                urlTextBox.Text = webBrowser.Source.ToString();
            }
            
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (webBrowser.CanGoForward)
            {
                webBrowser.GoForward();
                urlTextBox.Text = webBrowser.Source.ToString();
            }
                
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            webBrowser.Refresh();
            //urlTextBox.Text = webBrowser.Source.ToString();
        }

        
    }
}
