using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AP.ViewModels;

namespace AP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SongsListPage : ContentPage
	{
		public SongsListPage ()
		{
			InitializeComponent ();
            BindingContext = new SongsListViewModel() { Navigation = this.Navigation };
            
        }
            
        
	}
}