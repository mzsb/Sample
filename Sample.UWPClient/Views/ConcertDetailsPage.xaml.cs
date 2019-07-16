using Sample.DTO.Models;
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

            NavView.AppUser = viewModel.AppUser;

            viewModel.Concert = navObj.Get<Concert>();

            viewModel.NewConcertButtonVisibility = viewModel.AppUser.IsInRole(Roles.Administrator);

            NavView.AppUser = viewModel.AppUser;

            NavView.Concert = viewModel.Concert;

            NavView.NewConcertButtonVisibility = viewModel.NewConcertButtonVisibility;

            await viewModel.GetConcertDetails();

            base.OnNavigatedTo(e);
        }
    }
}
