using Newtonsoft.Json;
using Sample.DTO.Models;
using Sample.RestHelper.Models;
using Sample.UWPClient.Models;
using Sample.UWPClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.UWPClient.ViewModels
{
    class NewConcertViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ConcertService concertService = new ConcertService();

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


        private Concert concert = new Concert { Name = "teszt" };

        public Concert Concert
        {
            get { return concert; }
            set
            {
                if (concert != value)
                {
                    concert = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Concert)));
                }
            }
        }

        public async Task CreateConcert()
        {
            RestMethod restMethod = AppUser.GetMethod<Concert>(MethodType.Post, !string.IsNullOrEmpty("HasParameter"));

            if (restMethod != null)
            {
                restMethod.JsonBody = JsonConvert.SerializeObject(Concert);

                Concert = await concertService.CreateConcertAsync(restMethod);
            }
        }
    }
}
