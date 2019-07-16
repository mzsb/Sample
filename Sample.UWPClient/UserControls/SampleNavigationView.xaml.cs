using Sample.DTO.Models;
using Sample.UWPClient.Models;
using Sample.UWPClient.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Sample.UWPClient.UserControls
{
    public sealed partial class SampleNavigationView : UserControl
    {
        public SampleNavigationView()
        {
            this.InitializeComponent();
        }

        private Frame navigationFrame = Window.Current.Content as Frame;

        public AppUser AppUser { get; set; }

        public Concert Concert { get; set; }

        public bool NewConcertButtonVisibility { get; set; }

        public object NavigationContent
        {
            get { return GetValue(NavigationContentProperty); }
            set { SetValue(NavigationContentProperty, value); }
        }

        public static readonly DependencyProperty NavigationContentProperty =
        DependencyProperty.Register("NavigationContent", typeof(object), typeof(SampleNavigationView), new PropertyMetadata(0));


        // Esemenykezelok //

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigateToAuthenticationPage();
        }

        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            NavigateToConcertsPage();
        }
        private void Concerts_Click(object sender, RoutedEventArgs e)
        {
            NavigateToConcertsPage();
        }

        private void NewConcert_Click(object sender, RoutedEventArgs e)
        {
            NavigateToNewConcertPage();
        }


        // Navigacio //

        private void NavigateToNewConcertPage()
        {
            navigationFrame.Navigate(typeof(NewConcertPage),
                                     new NavigationObject().Add(AppUser));
        }

        private void NavigateToConcertsPage()
        {
            navigationFrame.Navigate(typeof(ConcertsPage),
                                     new NavigationObject().Add(AppUser));
        }

        private void NavigateToAuthenticationPage()
        {
            navigationFrame.Navigate(typeof(AuthenticationPage),
                                     new NavigationObject().Add(AppUser));
        }
    }
}
