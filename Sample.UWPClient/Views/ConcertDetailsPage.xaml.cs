using Sample.UWPClient.Helper;
using Sample.UWPClient.Models;
using Sample.UWPClient.ViewModels;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sample.UWPClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConcertDetailsPage : Page
    {
        private readonly ConcertDetailsViewModel viewModel = new ConcertDetailsViewModel();

        public ConcertDetailsPage()
        {
            this.InitializeComponent();
            DataContext = viewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var navObj = new NavigationObject(e.Parameter);

            viewModel.AppUser = navObj.Get<AppUser>();

            viewModel.Concert = navObj.Get<Concert>();

            viewModel.NewConcertButtonVisibility = viewModel.AppUser.IsInRole(Roles.Administrator);

            await viewModel.GetConcertDetails();

            base.OnNavigatedTo(e);
        }


        // Esemenykezelok //

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            NavigateToAuthenticationPage();
        }

        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
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
            Frame.Navigate(typeof(NewConcertPage),
                           new NavigationObject().Add(viewModel.AppUser));
        }

        private void NavigateToConcertsPage()
        {
            Frame.Navigate(typeof(ConcertsPage),
                           new NavigationObject().Add(viewModel.AppUser));
        }

        private void NavigateToAuthenticationPage()
        {
            Frame.Navigate(typeof(AuthenticationPage),
                           new NavigationObject().Add(viewModel.AppUser));
        }
    }
}
