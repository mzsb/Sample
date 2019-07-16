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
using Sample.UWPClient.Helper;
using Windows.UI.Core;
using Sample.RestHelper.Models;
using Sample.DTO.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sample.UWPClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConcertsPage : Page
    {
        private readonly ConcertsViewModel viewModel = new ConcertsViewModel();

        public ConcertsPage()
        {
            this.InitializeComponent();
            DataContext = viewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var navObj = new NavigationObject(e.Parameter);

            var appUser = navObj.Get<AppUser>();

            viewModel.AppUser = navObj.Get<AppUser>();

            viewModel.NewConcertButtonVisibility = viewModel.AppUser.IsInRole(Roles.Administrator);

            NavView.AppUser = viewModel.AppUser;

            NavView.NewConcertButtonVisibility = viewModel.NewConcertButtonVisibility;

            await viewModel.GetConcerts();


            base.OnNavigatedTo(e);
        }


        // Esemenykezelok //

        private void ConcertItem_Click(object sender, ItemClickEventArgs e)
        {
            NavigateToConcertDetailsPage((Concert)e.ClickedItem);
        }


        // Navigacio //

        private void NavigateToConcertDetailsPage(Concert concert)
        {
            Frame.Navigate(typeof(ConcertDetailsPage),
                           new NavigationObject().Add(viewModel.AppUser, concert));
        }
    }
}
