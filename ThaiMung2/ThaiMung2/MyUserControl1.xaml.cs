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
    public sealed partial class MyUserControl1 : UserControl
    {
        public bool flState = false;
        public MyUserControl1()
        {
            this.InitializeComponent();
        }

        public void OnClosingEvent(object sender)
        {
            try
            {
                tagFlyoutPopup.IsOpen = false;
                Canvas.SetLeft(tagFlyoutPopup, Window.Current.Bounds.Width + 10);
                flState = false;
            }
            catch { }
        }

        public void show()
        {
            double ScreenW = Window.Current.Bounds.Width;
            double ScreenH = Window.Current.Bounds.Height;
            mainTagBorder.Width = 244;
            mainTagBorder.Height = 380;


            tagFlyoutPopup.IsOpen = true;
            Canvas.SetLeft(tagFlyoutPopup, 138);
            Canvas.SetTop(tagFlyoutPopup, ScreenH - 468);
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
            Canvas.SetLeft(tagFlyoutPopup, Window.Current.Bounds.Width);

            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            Window.Current.Activated -= OnWindowActivated;
        }

        private void OnPopupClosed(object sender, object e)
        {
            Hide();
        }

        private void saveTagButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }

    
}
