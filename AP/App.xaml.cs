using AP.Views;
using AP.ViewModels;
using AP.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage( new MainPage());
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //Main.CurrentSongsListViewModel.CreateInstantSongs();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
