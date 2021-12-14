using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using App1.Models;
using Xamarin.Forms;
using App1.ViewModel;

namespace App1.ViewModels
{
   

    class UserViewModel : BaseViewModel
    {
        public string gmail;
        public string password;
       
        public string GmailTxt
        {
            get
            {
                return this.gmail;
            }
            set { SetValue(ref this.gmail, value); }
        }
        public string PasswordTxt
        {
            get
            {
                return this.password;
            }
            set { SetValue(ref this.password, value); }
        }

      
        #region Commands

        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }
            set { }
        }

        #endregion


        #region Methods

        public async void RegisterMethod()
        {
            var userMod = new User();
            userMod.Gmail = gmail;
            userMod.Password = password;
            
            await App.Db.SaveModelAsync(userMod , true);

            await Application.Current.MainPage.DisplayAlert("OK", gmail + " Registro Exitoso", "OK");

        }

        #endregion
    }
}
