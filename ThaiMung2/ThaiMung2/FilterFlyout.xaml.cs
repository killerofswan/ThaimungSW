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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ThaiMung2
{
    public sealed partial class FilterFlyout : UserControl
    {
        public bool flState = false;
        public FilterFlyout()
        {
            this.InitializeComponent();
        }

        public void OnClosingEvent(object sender)
        {
            try
            {
                filterFlyoutPopup.IsOpen = false;
                Canvas.SetLeft(filterFlyoutPopup, Window.Current.Bounds.Width + 10);
                flState = false;
            }
            catch { }
        }

        public void Show()
        {

            double ScreenW = Window.Current.Bounds.Width;
            double ScreenH = Window.Current.Bounds.Height;
            mainFilterBorder.Width = 400;
            mainFilterBorder.Height = ScreenH;


            filterFlyoutPopup.IsOpen = true;
            Canvas.SetLeft(filterFlyoutPopup, ScreenW - 400);
            flState = true;

            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.Activated += OnWindowActivated;
        }

        private void OnWindowActivated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                Hide();
            }
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            Hide();
        }

        public void Hide()
        {
            flState = false;
            OnClosingEvent(this);
            Window.Current.Activated -= OnWindowActivated;
            Canvas.SetLeft(filterFlyoutPopup, Window.Current.Bounds.Width);

            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            Window.Current.Activated -= OnWindowActivated;
        }

        private void OnPopupClosed(object sender, object e)
        {
            Hide();
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
        
    }
}
