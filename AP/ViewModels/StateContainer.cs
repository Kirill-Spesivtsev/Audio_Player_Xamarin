using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AP.ViewModels
{
    class StateContainer
    {
        [ContentProperty("Content")]
        public class StateCondition : View
        {
            public object State { get; set; }
            public View Content { get; set; }

            public enum States
            {
                Loading,
                Normal,
                Error,
                NoInternet,
                NoData
            }
        }
    }
}
