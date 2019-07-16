using Sample.DTO.Models;
using Sample.RestHelper.Models;
using Sample.UWPClient.Models;
using Sample.UWPClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.UWPClient.ViewModels
{
    class ConcertsViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public readonly HttpService httpService = new HttpService();

        public ObservableCollection<Concert> SoonConcerts { get; set; } = new ObservableCollection<Concert>();

        private AppUser appUser = new AppUser();

        public AppUser AppUser
        {
            get { return appUser; }
            set
            {
                if (appUser != value)
                {
                    appUser = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AppUser)));
                }
            }
        }

        private bool newConcertButtonVisibility = false;
        public bool NewConcertButtonVisibility
        {
            get { return newConcertButtonVisibility; }
            set
            {
                if (newConcertButtonVisibility != value)
                {
                    newConcertButtonVisibility = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewConcertButtonVisibility)));
                }
            }
        }

        public async Task GetConcerts()
        {
            RestMethod restMethod = AppUser.GetMethod<Concert>(MethodType.Get);

            if (restMethod != null)
            {
                List<Concert> concerts = await httpService.HttpRequestAsync<List<Concert>>(restMethod);

                foreach (var item in concerts)
                {
                    SoonConcerts.Add(item);
                }
            }
        }
    }
}
