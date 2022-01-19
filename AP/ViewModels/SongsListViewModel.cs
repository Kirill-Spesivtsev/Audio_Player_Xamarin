using MyAP = MediaManager.CrossMediaManager;
using MediaManager.Forms;
using Player = MediaManager.Player;
using Queue = MediaManager.Queue;
using MediaManager.Notifications;
using MediaManager;
using MediaManager.Player;
using MediaManager.Platforms;
using MediaManager.Playback;
using MediaManager.Media;
using MediaManager.Library;
using Android.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using AP.Views;
using Plugin.FilePicker;
using System.Threading;
using AP.Models;
using System.Threading.Tasks;
using Plugin.FilePicker.Abstractions;
using Android.Graphics;
using System.IO;

namespace AP.ViewModels
{
    public class SongsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SongViewModel> Songs { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateSongCommand { protected set; get; }
        //public ICommand CreateInstantSongsCommand { protected set; get; }
        public ICommand DeleteSongCommand { protected set; get; }
        public ICommand SaveSongCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        SongViewModel selectedSong;

        public int BackGroundColor { get; protected set; } = 0xf57b42;


        public INavigation Navigation { get; set; }

        public SongsListViewModel()
        {
            Songs = new ObservableCollection<SongViewModel>();
            Main.CurrentSongsListViewModel = this;
            Main.CurrentSongsListViewModel.CreateInstantSongs();
            CreateSongCommand = new Command(CreateSong);
            //CreateInstantSongsCommand = new Command(CreateInstantSongs());
            DeleteSongCommand = new Command(DeleteSong);
            SaveSongCommand = new Command(SaveSong);
            BackCommand = new Command(Back);
            //Device.StartTimer(TimeSpan.FromMilliseconds(300), OnTimer);
        }

        public SongViewModel SelectedSong
        {
            get { return selectedSong; }
            set
            {
                if (selectedSong != value)
                {
                    SongViewModel tempSong = value;
                    selectedSong = null;
                    OnPropertyChanged("SelectedSong");
                    Navigation.PushAsync(new SongPage(tempSong), true);
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void CreateSong()
        {
            //Navigation.PushAsync(new SongPage(new SongViewModel() { CurrentListViewModel = this }));
            FileData filedata = await CrossFilePicker.Current.PickFile();
            if (filedata.FilePath != null)
                await LoadSongFromPath(filedata.FilePath);
        }

        private bool OnTimer() 
        {
            return true; 
        }

        public async void CreateInstantSongs()
        {
            Songs.Add(new SongViewModel("SSSS", "ghi", "hhfdk") { CurrentListViewModel = this });
            Songs.Add(new SongViewModel("AAAA", "jdv", "oedcjk") { CurrentListViewModel = this });
            Songs.Add(new SongViewModel("BBBB", "kdc", "djei") { CurrentListViewModel = this });
            Songs.Add(new SongViewModel("CCCC", "skdm", "dhsiu") { CurrentListViewModel = this });
            await LoadSongFromPath((string)Android.OS.Environment.ExternalStorageDirectory + @"/Music/Starset_-_my_demons.mp3");
            await LoadSongFromPath((string)Android.OS.Environment.ExternalStorageDirectory + @"/Music/Linkin_Park_-_Papercut.mp3");
            await LoadSongFromPath((string)Android.OS.Environment.ExternalStorageDirectory + @"/Music/Egypt_central-over_and_under.mp3");
            await LoadSongFromPath((string)Android.OS.Environment.ExternalStorageDirectory + @"/Music/Hollywood_undead-levitate.mp3");
            await LoadSongFromPath((string)Android.OS.Environment.ExternalStorageDirectory + @"/Music/Thousand_foot_krutch-take_it_out_on_me.mp3");
        
        }

        public Task LoadSongFromPath(string path) 
        {


            //FileData filedata = await CrossFilePicker.Current.PickFile();
            MediaMetadataRetriever reader = new MediaMetadataRetriever();
            reader.SetDataSource(path);

            //byte[] art = reader.GetEmbeddedPicture();
                //image.Source = ImageSource.FromStream(() => new MemoryStream(reader.GetEmbeddedPicture()));
                //img
                
            Songs.Add(new SongViewModel(path, reader.ExtractMetadata(MetadataKey.Title), reader.ExtractMetadata(MetadataKey.Artist), reader.ExtractMetadata(MetadataKey.Album), reader.ExtractMetadata(MetadataKey.ImagePrimary)) { CurrentListViewModel = this });
            return Task.Delay(20);
        }
        private void Back()
        {
            Navigation.PopAsync(true);
        }
        private void SaveSong(object songObject)
        {
            SongViewModel sng = songObject as SongViewModel;
            if (sng != null && sng.IsValid)
            {
                Songs.Add(sng);
            }
            Back();
        }
        private void DeleteSong(object songObject)
        {
            SongViewModel sng = songObject as SongViewModel;
            if (sng != null)
            {
                Songs.Remove(sng);
            }
            Back();
        }

    }
}
