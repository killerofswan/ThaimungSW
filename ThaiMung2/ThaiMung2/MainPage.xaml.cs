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
            //getCurrentLocation();
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

        //public async void getCurrentLocation()
        //{
        //    // Change the state of our buttons.
        //   // MapLocationButton.IsEnabled = false;
        //    //CancelGetLocationButton.IsEnabled = true;

        //    // Remove any previous location icon.
        //    if (Map.Children.Count > 0)
        //    {
        //        Map.Children.RemoveAt(0);
        //    }

        //    try
        //    {
        //        // Get the cancellation token.
        //        _cts = new CancellationTokenSource();
        //        CancellationToken token = _cts.Token;

        //        //MessageTextbox.Text = "Waiting for update...";

        //        // Get the location.
        //        Geoposition pos = await _geolocator.GetGeopositionAsync().AsTask(token);

        //        //MessageTextbox.Text = "";

        //        Location location = new Location(pos.Coordinate.Latitude, pos.Coordinate.Longitude);

        //        // Now set the zoom level of the map based on the accuracy of our location data.
        //        // Default to IP level accuracy. We only show the region at this level - No icon is displayed.
        //        double zoomLevel = 13.0f;
        //        //Debug.WriteLine("Current Snap");
        //        // if we have GPS level accuracy
        //        if (pos.Coordinate.Accuracy <= 10)
        //        {
        //            // Add the 10m icon and zoom closer.
        //            Map.Children.Add(_locationIcon10m);
        //            MapLayer.SetPosition(_locationIcon10m, location);
        //            zoomLevel = 15.0f;
        //        }
        //        // Else if we have Wi-Fi level accuracy.
        //        //else if (pos.Coordinate.Accuracy <= 100)
        //        else
        //        {
        //            // Add the 100m icon and zoom a little closer.
        //            Map.Children.Add(_locationIcon10m);
        //            MapLayer.SetPosition(_locationIcon10m, location);
        //            zoomLevel = 14.0f;
        //        }
               
        //        // Set the map to the given location and zoom level.
        //        Map.SetView(location, zoomLevel);

        //        // Display the location information in the textboxes.
        //        //LatitudeTextbox.Text = pos.Coordinate.Latitude.ToString();
        //        //LongitudeTextbox.Text = pos.Coordinate.Longitude.ToString();
        //        //AccuracyTextbox.Text = pos.Coordinate.Accuracy.ToString();
        //    }
        //    catch (System.UnauthorizedAccessException)
        //    {
        //        //MessageTextbox.Text = "Location disabled.";

        //        //LatitudeTextbox.Text = "No data";
        //        //LongitudeTextbox.Text = "No data";
        //        //AccuracyTextbox.Text = "No data";
        //    }
        //    catch (TaskCanceledException)
        //    {
        //       // MessageTextbox.Text = "Operation canceled.";
        //    }
        //    finally
        //    {
        //        _cts = null;
        //    }

          


        //    // Reset the buttons.
        //    //MapLocationButton.IsEnabled = true;
        //    //CancelGetLocationButton.IsEnabled = false;
        //}
    }
}
