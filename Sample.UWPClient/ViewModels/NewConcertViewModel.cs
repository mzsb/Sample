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
        public DataFrame<AppUser> DataFrame { get; set; }

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

        public async Task<Concert> CreateConcert()
        {
            RestMeta restMeta = DataFrame.RestMetas.Where(rm => rm.Method.Equals("CreateConcert"))
                                                 .FirstOrDefault();

            if(restMeta != null)
            {
                return await concertService.CreateConcertAsync(Concert, restMeta);
            }

            return null;
        }
    }
}
