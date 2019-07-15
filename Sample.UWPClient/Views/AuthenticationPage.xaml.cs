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
using Sample.DTO.Models;
using Windows.UI.Popups;

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

            /// Temp ///
            viewModel.Login.UserName = "Admin";
            viewModel.Login.Password = "J1ezdmeg+";
            /// Temp ///

            base.OnNavigatedTo(e);
        }


        // Esemenykezelok //

        private async void Login_ClickAsync(object sender, RoutedEventArgs e)
        {
            await viewModel.LoginAsync();

            if(viewModel.AppUser != null)
            {
                NavigateToConcertsPage();
            }
            else
            {
                await new MessageDialog("Sikertelen bejelentkezés!").ShowAsync();
            }
        }

        private async void Registration_ClickAsync(object sender, RoutedEventArgs e)
        {
            await viewModel.RegistrationAsync();

            if (viewModel.AppUser != null)
            {
                NavigateToConcertsPage();
            }
            else
            {
                await new MessageDialog("Sikertelen regisztráció!").ShowAsync();
            }
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

        private void NavigateToConcertsPage()
        {
            Frame.Navigate(typeof(ConcertsPage), 
                           new NavigationObject().Add(viewModel.AppUser));
        }
    }
}
