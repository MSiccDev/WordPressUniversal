using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WordPressUniversal.Client;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace WindowsPhone81Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        WordPressClient wordpressClient;

        StatusBarProgressIndicator loadingAnimation;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowLoading("loading...");
            wordpressClient = new WordPressClient();

            var response = await wordpressClient.getPostList("apps.msicc.net", WordPressUniversal.Models.PostType.post, WordPressUniversal.Models.PostStatus.publish);

            HideLoading();

            MessageDialog msg = new MessageDialog(response.posts_list[0].post_title);
            await msg.ShowAsync();

        }


        async void ShowLoading(string text)
        {
            loadingAnimation = StatusBar.GetForCurrentView().ProgressIndicator;
            loadingAnimation.Text = text;
            await loadingAnimation.ShowAsync();
        }

        async void HideLoading()
        {
            await loadingAnimation.HideAsync();
        }
    }
}
