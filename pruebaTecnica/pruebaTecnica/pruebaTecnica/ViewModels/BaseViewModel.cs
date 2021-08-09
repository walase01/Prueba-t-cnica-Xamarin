using Prism.Services;
using pruebaTecnica.Services;
using pruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace pruebaTecnica.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IPageDialogService dialogService;
        protected IDatabaseService dabaseService;

        protected List<Address> listAddress = new List<Address>();
        public BaseViewModel(IDatabaseService _databaseService, IPageDialogService _dialogService)
        {
            this.dabaseService = _databaseService;
            this.dialogService = _dialogService;
        }

        public async void GetData()
        {
            listAddress = await dabaseService.GetListAddress();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
