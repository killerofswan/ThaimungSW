using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

using Windows.Devices.Geolocation;
using System.Threading;
using System.Threading.Tasks;
using Bing.Maps;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ThaiMung2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private Geolocator _geolocator = null;
        //private CancellationTokenSource _cts = null;
        //LocationIcon10m _locationIcon10m;
        //LocationIcon100m _locationIcon100m;

        MyMap map;
        FilterFlyout ft;
        public MainPage()
        {
            this.InitializeComponent();
            map = new MyMap();
            ft = new FilterFlyout();

            mainGrid.Children.Add(map);
            //_geolocator = new Geolocator();
            //_locationIcon10m = new LocationIcon10m();
            //_locationIcon100m = new LocationIcon100m();
            map.getCurrentLocation();
            map.getPost();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void writeEvent_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PostPage));
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            ft.Show();
        }

        
    }
}
