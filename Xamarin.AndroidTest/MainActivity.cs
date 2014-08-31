using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using WordPressUniversal.Client;

namespace Xamarin.AndroidTest
{
    [Activity(Label = "Xamarin.AndroidTest", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        WordPressClient wordpressclient;
        public ProgressDialog progress;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            wordpressclient = new WordPressClient();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += button_Click;
        }

        async void button_Click(object sender, EventArgs e)
        {
            ShowLoading("loading...");

            wordpressclient = new WordPressClient();
            var response = await wordpressclient.GetCategoriesList("msicc.net");

            HideLoading();
            
        }


        void ShowLoading(string text)
        {
            progress = new ProgressDialog(this) { Indeterminate = true };
            progress.SetCanceledOnTouchOutside(false);
            progress.SetProgressStyle(ProgressDialogStyle.Spinner);
            progress.SetMessage(text);
            progress.Show();
        }

        void HideLoading()
        {
            progress.Hide();
        }


    }
}

