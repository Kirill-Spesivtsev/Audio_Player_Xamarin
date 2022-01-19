using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AP.Models;
using Xamarin.Forms;

namespace AP.ViewModels
{
    public class SongViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        SongsListViewModel lvm;

        public Song song { get; private set; }

        public SongViewModel()
        {
            song = new Song();
        }

        public SongViewModel(string name, string author, string album) : this()
        {
            song.Name = name;
            OnPropertyChanged("Name");
            song.Author = author;
            OnPropertyChanged("Author");
            song.Album = album;
            OnPropertyChanged("Album");
        }

        public SongViewModel(string path, string name, string author, string album, ImageSource isource) : this()
        {
            song.Path = path;
            song.Name = name;
            OnPropertyChanged("Name");
            song.Author = author;
            OnPropertyChanged("Author");
            song.Album = album;
            OnPropertyChanged("Album");
            song.Image = isource;
        }

        public SongsListViewModel CurrentListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string Name
        {
            get { return song.Name; }
            set
            {
                if (song.Name != value)
                {
                    song.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Album
        {
            get { return song.Album; }
            set
            {
                if (song.Album != value)
                {
                    song.Album = value;
                    OnPropertyChanged("Album");
                }
            }
        }
        public string Author
        {
            get { return song.Author; }
            set
            {
                if (song.Author != value)
                {
                    song.Author = value;
                    OnPropertyChanged("Author");
                }
            }
        }
        /*
        public void AllChanged(string name, string author, string album)
        {
            Song.Name = name;
            OnPropertyChanged("Name");
            Song.Author = author;
            OnPropertyChanged("Author");
            Song.Album = album;
            OnPropertyChanged("Album");
        }
        */
        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())) ||
                    (!string.IsNullOrEmpty(Author.Trim())) ||
                    (!string.IsNullOrEmpty(Album.Trim())));
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
