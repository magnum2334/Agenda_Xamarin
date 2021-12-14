using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using App1.Models;
using Xamarin.Forms;
using App1.ViewModel;
using System.Threading.Tasks;
using App1.Views;

namespace App1.ViewModels
{


    class TaskViewModel : BaseViewModel
    {
        public string text;
        public string description;
        public bool isRefreshing = false;
        public object listViewSource;
        
        
        
        public string TextTxt
        {
            get
            {
                return this.text;
            }
            set { SetValue(ref this.text, value); }
        }
        public string DescriptionTxt
        {
            get
            {
                return this.description;
            }
            set { SetValue(ref this.description, value); }
        }


        #region Commands

        public ICommand TaskRegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }
            set { }
        }

        public bool IsRefreshing
        {
            get
            {
                return this.isRefreshing;
            }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public object ListViewSource
        {
            get
            {
                return this.listViewSource;
            }
            set { SetValue(ref this.listViewSource, value); }
        }
        public async Task LoadList()
        {
            this.ListViewSource = await App.Db.GetTableModel<Item>();
            
        }

        #endregion


        #region Methods

        public async void RegisterMethod()
        {
            var userMod = new Item();
            userMod.Text = text;
            userMod.Description = description;

            await App.Db.SaveModelAsync(userMod, true);

            await Application.Current.MainPage.DisplayAlert("Ok","Task created", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new Home());

        }


        public TaskViewModel()
        {
            LoadList();
            IsRefreshing = false;
        }
        #endregion
    }
}