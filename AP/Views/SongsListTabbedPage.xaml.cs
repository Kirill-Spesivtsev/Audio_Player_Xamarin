using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SongsListTabbedPage : TabbedPage
    {
        public SongsListTabbedPage()
        {
            InitializeComponent();
        }
    }
}