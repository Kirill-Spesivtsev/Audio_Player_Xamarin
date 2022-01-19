using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AP.Models
{
    public class Song
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Album { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Genres { get; set; }

        public ImageSource Image;

        public static implicit operator String (Song temp) { return temp.Path; }
    }
}
