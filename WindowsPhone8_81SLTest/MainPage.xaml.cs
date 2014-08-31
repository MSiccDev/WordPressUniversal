using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WindowsPhone8_81SLTest.Resources;
using WordPressUniversal.Client;

namespace WindowsPhone8_81SLTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        WordPressClient wordpressClient;

        ProgressIndicator progress;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowLoading("loading...");
            wordpressClient = new WordPressClient();

            var response = await wordpressClient.GetCategoriesList("msicc.net");

            HideLoading();
        }

        void ShowLoading(string text)
        {
            progress = new ProgressIndicator();
            progress.IsIndeterminate = true;
            progress.IsVisible = true;
            progress.Text = text;


            SystemTray.SetProgressIndicator(this, progress);
            SystemTray.IsVisible = true;

        }

        void HideLoading()
        {
            progress.IsIndeterminate = false;
            progress.IsVisible = false;
            SystemTray.IsVisible = false;
        }

    }
}