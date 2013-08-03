﻿using System;
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
using Bing.Maps;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TestBingMap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MyMap map;
        public MainPage()
        {
            this.InitializeComponent();
            double ScreenW = Window.Current.Bounds.Width;
            double ScreenH = Window.Current.Bounds.Height;
            map = new MyMap();
            mainGrid.Children.Add(map);
            mainGrid.Width = ScreenW;
            mainGrid.Height = ScreenH;
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
            //Frame.Navigate(typeof(PostPage));
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            //ft.Show();
        }
        
    }
}
