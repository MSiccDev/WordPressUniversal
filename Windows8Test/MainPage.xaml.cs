using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WordPressUniversal.Client;
using WordPressUniversal.Helpers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows8Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        WordPressClient wordpressClient;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowProgressBar();
            wordpressClient = new WordPressClient();

            var response = await wordpressClient.getPostList("msicc.net", WordPressUniversal.Helpers.PostType.post, WordPressUniversal.Helpers.PostStatus.publish);

            HideProgressBar();

            //getting string of JObject Keys in post_categories
            var postcats = PostCategories.GetString(response.posts_list[0].post_categories);

            MessageDialog msg = new MessageDialog(postcats);
            await msg.ShowAsync();

            
           
        }

        private void ShowProgressBar()
        {
            loadingProgressBar.Visibility = Visibility.Visible;
            loadingProgressBar.IsIndeterminate = true;
        }

        private void HideProgressBar()
        {
            loadingProgressBar.Visibility = Visibility.Collapsed;
            loadingProgressBar.IsIndeterminate = false;
        }
    }
}
