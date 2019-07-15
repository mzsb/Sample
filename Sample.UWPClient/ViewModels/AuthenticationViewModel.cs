using Sample.UWPClient.Models;
using Sample.UWPClient.Services;
using Sample.UWPClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;
using Sample.UWPClient.Helper;
using Sample.DTO.Models;

namespace Sample.UWPClient.ViewModels
{
    public class AuthenticationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public readonly AuthenticationService authenticationService = new AuthenticationService();

        public AppUser AppUser { get; set; }

        private Login login = new Login();

        public Login Login
        {
            get { return login; }
            set
            {
                if (login != value)
                {
                    login = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Login)));
                }
            }
        }

        private Registration registration = new Registration();

        public Registration Registration
        {
            get { return registration; }
            set
            {
                if (registration != value)
                {
                    registration = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Registration)));
                }
            }
        }

        private bool loginPanelVisibility = true;
        public bool LoginPanelVisibility
        {
            get { return loginPanelVisibility; }
            set
            {
                if (loginPanelVisibility != value)
                {
                    loginPanelVisibility = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoginPanelVisibility)));
                }
            }
        }

        private bool registerPanelVisibility = false;
        public bool RegisterPanelVisibility
        {
            get { return registerPanelVisibility; }
            set
            {
                if (registerPanelVisibility != value)
                {
                    registerPanelVisibility = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RegisterPanelVisibility)));
                }
            }
        }

        public async Task LoginAsync()
        {
            if (await Login.IsValid())
            {
                AppUser = await authenticationService.LoginAsync(Login);

                ServiceBase.Token = AppUser.Token ?? string.Empty;
            }
        }

        public async Task RegistrationAsync()
        {
            if(await Registration.IsValid())
            {
                AppUser = await authenticationService.RegistrationAsync(Registration);

                ServiceBase.Token = AppUser.Token ?? string.Empty;
            }
        }
    }
}
