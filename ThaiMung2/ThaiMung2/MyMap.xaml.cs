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

using System.Diagnostics;

using Newtonsoft.Json.Linq;
using System.Net.Http;

using System.Collections;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ThaiMung2
{
    public sealed partial class MyMap : UserControl
    {
        private Geolocator _geolocator = null;
        private CancellationTokenSource _cts = null;
        LocationIcon10m _locationIcon10m;
        LocationIcon100m _locationIcon100m;
        List<Post> post = new List<Post>();
        Dictionary<int, Post> p = new Dictionary<int, Post>();
        
        PostPage ps;

        public MyMap()
        {
              
            this.InitializeComponent();
            _geolocator = new Geolocator();
            _locationIcon10m = new LocationIcon10m();
            _locationIcon100m = new LocationIcon100m();
            //getCurrentLocation();
            //getPost();
            ps = new PostPage();
        }

        public MyMap(double width, double height,PostPage page)
        {
            this.InitializeComponent();
            

            _geolocator = new Geolocator();
            _locationIcon10m = new LocationIcon10m();
            _locationIcon100m = new LocationIcon100m();
            Map.Height = height;
            Map.Width = width;

            ps = page;
            //getCurrentLocation();
            //getPost();
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

        private void mapTapped(object sender, TappedRoutedEventArgs e)
        {
            Map.Children.Clear();
            // Disables the default mouse double-click action.
            e.Handled = true;

            // Determin the location to place the pushpin at on the map.

            //Get the mouse click coordinates
            Point tapPosition = e.GetPosition(this);
            //Convert the mouse coordinates to a locatoin on the map
            
            //Location pinLocation = Map.ViewportPointToLocation(mousePosition);
            Location location;
            Map.TryPixelToLocation(tapPosition, out location);

            Debug.WriteLine(sender.ToString());
            
            ps.setLocation(location.Latitude.ToString(),location.Longitude.ToString());

            // The pushpin to add to the map.
            Pushpin pin = new Pushpin();
            //pin.Location = pinLocation;
            MapLayer.SetPosition(pin, location);
            
            // Adds the pushpin to the map.
            Map.Children.Add(pin);
            Map.SetView(location);
        }

        public async void getPost()
        {
            post.Clear();
            p.Clear();
            // Map.Children.Clear();

            HttpClient client = new HttpClient();
            var postData = new List<KeyValuePair<string, string>>();
            //postData.Add(new KeyValuePair<string, string>("latitude", lati.ToString()));
            //postData.Add(new KeyValuePair<string, string>("longtitude", longti.ToString()));
            postData.Add(new KeyValuePair<string, string>("uid", "44"));
            HttpContent c = new FormUrlEncodedContent(postData);
            var response = await client.PostAsync("http://localhost/view.php", c);

            var str = await response.Content.ReadAsStringAsync();

            string s = str.ToString();

            Debug.WriteLine(s);

            if (s.Equals("Not Found"))
            {
                Debug.WriteLine("in if not found");
                //Pushpin pin = new Pushpin();

                //pin.Text = "error";
                //MapLayer.SetPosition(pin, new Location(14.27570, 101.2890));
                ////pushpin.Tapped += new TappedEventHandler(pushpinTapped);
                //Map.Children.Add(pin);
            }
            else
            {
                var o = JArray.Parse(s);

                Debug.WriteLine("in else");
                int i = 0;
                Debug.WriteLine("o.count = " + o.Count);
                while (i < o.Count)
                {

                    Post tmp = new Post();

                    tmp.p_id = (int)o[i]["p_id"];

                    tmp.latitude = (double)o[i]["latitude"];

                    tmp.longtitude = (double)o[i]["longtitude"];

                    tmp.dateTime = (string)o[i]["date_time"];

                    tmp.id = (int)o[i]["id"];

                    tmp.description = (string)o[i]["description"];

                    tmp.status = (int)o[i]["status"];

                    tmp.countSolve = (int)o[i]["count_solved"];

                    tmp.countSeen = (int)o[i]["count_seen"];

                    tmp.countSpam = (int)o[i]["count_spam"];

                    tmp.nameTag.Add((string)o[i]["nametag"]);
                    Debug.WriteLine("while else");
                    i++;
                    if (i >= o.Count)
                    {
                        post.Add(tmp);
                        p.Add(tmp.p_id, tmp);
                    }
                    else
                    {
                        if (tmp.p_id != (int)o[i]["p_id"])
                        {
                            Debug.WriteLine("not multi Tag");
                            post.Add(tmp);
                            p.Add(tmp.p_id, tmp);
                            continue;
                        }
                        else
                        {
                            while (tmp.p_id == (int)o[i]["p_id"])
                            {
                                Debug.WriteLine("add multi nameTag");
                                tmp.nameTag.Add((string)o[i]["nametag"]);
                                i++;
                            }
                            Debug.WriteLine("after add multi nameTag");
                            post.Add(tmp);
                            p.Add(tmp.p_id,tmp);
                            
                        }
                    }
                }
                Debug.WriteLine("Before add");
                foreach (var item in p)
                {
                    Debug.WriteLine("foreach add");
                    Debug.WriteLine(item.Value.p_id + " " + item.Value.nameTag.ElementAt(0).ToString());
                    Pushpin pushpin = new Pushpin();
                    pushpin.Text = item.Value.p_id.ToString();
                    Location locate = new Location(item.Value.latitude, item.Value.longtitude);
                    MapLayer.SetPosition(pushpin, locate);
                    pushpin.Tapped += new TappedEventHandler(pushpinTapped);
                    Map.Children.Add(pushpin);
                }           
            }
        }

        private async void pushpinTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //MessageDialog dialog = new MessageDialog("Hello from Seattle.");
            //await dialog.ShowAsync();
           string txt =  ((Pushpin)sender).Text;
           int pid = Convert.ToInt32(txt);
           Post tmp = p[pid];
            
            

        }



    }
}
