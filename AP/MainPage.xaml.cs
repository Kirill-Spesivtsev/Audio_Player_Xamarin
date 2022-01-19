using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AP.ViewModels;
using AP.Views;

namespace AP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AboutButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Информация", "AudioPlayer v1.0.5.1", "OK");
        }

        private void ToListButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SongsListTabbedPage(), true);
        }
    }
}
