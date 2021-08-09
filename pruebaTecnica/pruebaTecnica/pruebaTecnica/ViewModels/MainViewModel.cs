using Prism.Commands;
using pruebaTecnica.Services;
using pruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Prism.Services;
using System.Collections.ObjectModel;

namespace pruebaTecnica.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public DelegateCommand InsertAddress { get; set; }
        public ObservableCollection<Address> ListAddress => new ObservableCollection<Address>(listAddress);

        public ObservableCollection<Address> FullListAddress { get; set; } 

        public MainViewModel(IDatabaseService databaseService, IPageDialogService dialogService): base (databaseService,dialogService)
        {
            InsertAddress = new DelegateCommand(SaveAddress);
            FullListAddress = ListAddress;
        }

        private async void SaveAddress()
        {
            if (Empty(City, Country))
            {
                Address address = new Address();

                address.City = City;
                address.Country = Country;

                await dabaseService.InsertAddress(address);
                await dialogService.DisplayAlertAsync("Confirm", "Correctly", "OK");
            }
            else
            {
               await  dialogService.DisplayAlertAsync("Empty cells", "fill in the cells","OK");
            }

        }

        public bool Empty(string city,string country)
        {
            if(!String.IsNullOrEmpty(city) && !String.IsNullOrEmpty(country))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
