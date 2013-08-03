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

using Newtonsoft.Json.Linq;
using System.Net.Http;

using System.Diagnostics;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ThaiMung2
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class PostPage : ThaiMung2.Common.LayoutAwarePage
    {
        private Geolocator _geolocator = null;
        private CancellationTokenSource _cts = null;
        LocationIcon10m _locationIcon10m;
        LocationIcon100m _locationIcon100m;
        MyUserControl1 tag;
        private string tag_id;
        
        MyMap pMap;
        public PostPage()
        {
            this.InitializeComponent();

            tag = new MyUserControl1(this);
            //_geolocator = new Geolocator();
            //_locationIcon10m = new LocationIcon10m();
            //Map.Children.Add(_locationIcon10m);
            //_locationIcon100m = new LocationIcon100m();
            pMap = new MyMap(498, 498,this);
            postMap.Children.Add(pMap);
            pMap.getCurrentLocation();

            
            //getCurrentLocation();
            date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            
            //pMap = new MyMap(498,498);
            //postMap.Children.Add(pMap);
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        /// 

        //public async void getCurrentLocation()
        //{
        //    // Change the state of our buttons.
        //    //MapLocationButton.IsEnabled = false;
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

        //        // if we have GPS level accuracy
        //        if (pos.Coordinate.Accuracy <= 10)
        //        {
        //            // Add the 10m icon and zoom closer.
        //            //Map.Children.Add(_locationIcon10m);
        //            Pushpin push10 = new Pushpin();
        //            Map.Children.Add(push10);
        //            MapLayer.SetPosition(push10, location);
        //            //MapLayer.SetPosition(_locationIcon10m, location);
        //            zoomLevel = 15.0f;
        //        }
        //        // Else if we have Wi-Fi level accuracy.
        //        //else if (pos.Coordinate.Accuracy <= 100)
        //        else
        //        {
        //            // Add the 100m icon and zoom a little closer.
        //            //Pushpin push = new Pushpin();
        //            Map.Children.Add(_locationIcon100m);
        //            //Map.Children.Add(push);
        //            MapLayer.SetPosition(_locationIcon100m, location);
        //            //MapLayer.SetPosition(push, location);
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
        //        // MessageTextbox.Text = "Location disabled.";

        //        //LatitudeTextbox.Text = "No data";
        //        //LongitudeTextbox.Text = "No data";
        //        //AccuracyTextbox.Text = "No data";
        //    }
        //    catch (TaskCanceledException)
        //    {
        //        //MessageTextbox.Text = "Operation canceled.";
        //    }
        //    finally
        //    {
        //        _cts = null;
        //    }

        //    // Reset the buttons.
        //    //MapLocationButton.IsEnabled = true;
        //    //CancelGetLocationButton.IsEnabled = false; ;
        //}
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void tagButton_Click(object sender, RoutedEventArgs e)
        {
            tag.show();
        }

        private async void saveTag_Click(object sender, RoutedEventArgs e)
        {
           
          
        }

        //private void Map_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    Map.Children.Clear();
        //    // Disables the default mouse double-click action.
        //    e.Handled = true;

        //    // Determin the location to place the pushpin at on the map.

        //    //Get the mouse click coordinates
        //    Point tapPosition = e.GetPosition(this);
        //    //Convert the mouse coordinates to a locatoin on the map

        //    //Location pinLocation = Map.ViewportPointToLocation(mousePosition);
        //    Location location;
        //    Map.TryPixelToLocation(tapPosition, out location);
             
        //    latitude.Text = location.Latitude.ToString();
        //    longtitude.Text = location.Longitude.ToString();

        //    // The pushpin to add to the map.
        //    Pushpin pin = new Pushpin();
        //    //pin.Location = pinLocation;
        //    MapLayer.SetPosition(pin, location);

        //    // Adds the pushpin to the map.
        //    Map.Children.Add(pin);
        //    Map.SetView(location);
        //}

        private async void postButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var postData = new List<KeyValuePair<string, string>>();
            String curTime = TimeHour.SelectedItem.ToString() + ":" + TimeMinute.SelectedItem.ToString() + ":00";
            String dateTime = date.Text + " " + curTime;

            postData.Add(new KeyValuePair<string, string>("latitude", latitude.Text));
            postData.Add(new KeyValuePair<string, string>("longtitude", longtitude.Text));
            postData.Add(new KeyValuePair<string, string>("date_time", dateTime));
            postData.Add(new KeyValuePair<string, string>("id", "44"));
            postData.Add(new KeyValuePair<string, string>("description", DescriptionText.Text));
            postData.Add(new KeyValuePair<string, string>("tag_id", tag_id));
            


            HttpContent c = new FormUrlEncodedContent(postData);
            var response = await client.PostAsync("http://localhost/post.php", c);
            var str = await response.Content.ReadAsStringAsync();
            string s = str.ToString();
            Debug.WriteLine(s);
        }
        public void setTagsStr(string s) {
            Tags.Text = s;
        }

        public void setTagsId(string s) {
            tag_id = s;
        }

        public void setLocation(string lati, string longti) {
            latitude.Text = lati;
            longtitude.Text = longti;
        }
    }
}
