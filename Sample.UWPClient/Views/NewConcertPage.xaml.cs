using Sample.DTO.Models;
using Sample.RestHelper.Models;
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
    public sealed partial class NewConcertPage : Page
    {
        private readonly NewConcertViewModel viewModel = new NewConcertViewModel();

        public NewConcertPage()
        {
            this.InitializeComponent();

            DataContext = viewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var navObj = new NavigationObject(e.Parameter);

            viewModel.AppUser = navObj.Get<AppUser>();

            NavView.AppUser = viewModel.AppUser;

            NavView.NewConcertButtonVisibility = true;

            base.OnNavigatedTo(e);
        }


        // Esemenykezelok //

        private async void CreateConcert_Click(object sender, RoutedEventArgs e)
        {
            await viewModel.CreateConcert();

            if(viewModel.Concert != null)
            {
                NavigateToConcertDetailsPage();
            }
        }

        private void NavigateToConcertDetailsPage()
        {
            Frame.Navigate(typeof(ConcertDetailsPage),
                           new NavigationObject().Add(viewModel.AppUser, viewModel.Concert));
        }
    }
}
