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

using Windows.Devices.Geolocation;
using System.Threading;
using System.Threading.Tasks;
using Bing.Maps;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TestBingMap
{
    public sealed partial class MyMap : UserControl
    {
        private Geolocator _geolocator = null;
        private CancellationTokenSource _cts = null;
        LocationIcon10m _locationIcon10m;
        LocationIcon100m _locationIcon100m;

        public MyMap()
        {
            this.InitializeComponent();
            _geolocator = new Geolocator();
            _locationIcon10m = new LocationIcon10m();
            _locationIcon100m = new LocationIcon100m();
            getCurrentLocation();        
        }

        public async void getCurrentLocation()
        {
            // Change the state of our buttons.
            //MapLocationButton.IsEnabled = false;
            //CancelGetLocationButton.IsEnabled = true;

            // Remove any previous location icon.
            if (Map.Children.Count > 0)
            {
                Map.Children.RemoveAt(0);
            }

            try
            {
                // Get the cancellation token.
                _cts = new CancellationTokenSource();
                CancellationToken token = _cts.Token;

                //MessageTextbox.Text = "Waiting for update...";

                // Get the location.
                Geoposition pos = await _geolocator.GetGeopositionAsync().AsTask(token);

                //MessageTextbox.Text = "";

                Location location = new Location(pos.Coordinate.Latitude, pos.Coordinate.Longitude);

                // Now set the zoom level of the map based on the accuracy of our location data.
                // Default to IP level accuracy. We only show the region at this level - No icon is displayed.
                double zoomLevel = 13.0f;

                // if we have GPS level accuracy
                if (pos.Coordinate.Accuracy <= 10)
                {
                    // Add the 10m icon and zoom closer.
                    //Map.Children.Add(_locationIcon10m);
                    Pushpin push10 = new Pushpin();
                    Map.Children.Add(push10);
                    MapLayer.SetPosition(push10, location);
                    //MapLayer.SetPosition(_locationIcon10m, location);
                    zoomLevel = 15.0f;
                }
                // Else if we have Wi-Fi level accuracy.
                //else if (pos.Coordinate.Accuracy <= 100)
                else
                {
                    // Add the 100m icon and zoom a little closer.
                    //Pushpin push = new Pushpin();
                    Map.Children.Add(_locationIcon100m);
                    //Map.Children.Add(push);
                    MapLayer.SetPosition(_locationIcon100m, location);
                    //MapLayer.SetPosition(push, location);
                    zoomLevel = 14.0f;
                }

                // Set the map to the given location and zoom level.
                Map.SetView(location, zoomLevel);

                // Display the location information in the textboxes.
                //LatitudeTextbox.Text = pos.Coordinate.Latitude.ToString();
                //LongitudeTextbox.Text = pos.Coordinate.Longitude.ToString();
                //AccuracyTextbox.Text = pos.Coordinate.Accuracy.ToString();
            }
            catch (System.UnauthorizedAccessException)
            {
               // MessageTextbox.Text = "Location disabled.";

                //LatitudeTextbox.Text = "No data";
                //LongitudeTextbox.Text = "No data";
                //AccuracyTextbox.Text = "No data";
            }
            catch (TaskCanceledException)
            {
                //MessageTextbox.Text = "Operation canceled.";
            }
            finally
            {
                _cts = null;
            }

            // Reset the buttons.
            //MapLocationButton.IsEnabled = true;
            //CancelGetLocationButton.IsEnabled = false; ;
        }

        
    }
}
