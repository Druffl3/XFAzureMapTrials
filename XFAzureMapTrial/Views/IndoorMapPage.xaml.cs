using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XFAzureMapTrial.Views
{
    public partial class IndoorMapPage : ContentPage
    {
        public IndoorMapPage()
        {
            InitializeComponent();
            this.indoorMap.Source = AppConstants.EndPoint;
        }
    }
}