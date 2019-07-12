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
    public class ConcertDetailsViewModel : INotifyPropertyChanged
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

        private Concert concert = new Concert();
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

        public async Task GetConcertDetails()
        {
            RestMeta restMeta = Concert.RestMetas.Where(rm => rm.Method.Equals("GetConcertDetails"))
                                                 .FirstOrDefault();

            if(restMeta != null)
            {
                Concert = await concertService.GetConcertsDetailsAsync(restMeta);
            }
        }
    }
}
