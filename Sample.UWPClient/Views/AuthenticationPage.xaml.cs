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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sample.UWPClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AuthenticationPage : Page
    {
        private readonly AuthenticationViewModel viewModel = new AuthenticationViewModel();

        public AuthenticationPage()
        {
            this.InitializeComponent();
            DataContext = viewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel.Login.Reset();
            viewModel.Registration.Reset();

            var navObj = new NavigationObject(e.Parameter);

            viewModel.Login.UserName = navObj.Get<AppUser>().UserName;

            viewModel.Login.UserName = "Admin";
            viewModel.Login.Password = "J1ezdmeg+";

            base.OnNavigatedTo(e);
        }


        // Esemenykezelok //

        private async void Login_ClickAsync(object sender, RoutedEventArgs e)
        {
            var appUser = await viewModel.LoginAsync();

            if(appUser != null)
            {
                Token.Value = appUser.Token;
            }

            NavigateToConcertsPage(appUser);
        }

        private async void Registration_ClickAsync(object sender, RoutedEventArgs e)
        {
            AppUser appUser = await viewModel.RegistrationAsync();

            if (appUser != null)
            {
                Token.Value = appUser.Token;
            }

            NavigateToConcertsPage(appUser);
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            viewModel.LoginPanelVisibility = false;

            viewModel.RegisterPanelVisibility = true;
        }

        private void CancelRegistration_Click(object sender, RoutedEventArgs e)
        {
            viewModel.LoginPanelVisibility = true;

            viewModel.RegisterPanelVisibility = false;
        }


        // Navigacio //

        private void NavigateToConcertsPage(AppUser appUser)
        {
            if (appUser != null)
            {
                Frame.Navigate(typeof(ConcertsPage), 
                               new NavigationObject().Add(appUser, viewModel.DataFrame));
            }
        }
    }
}
