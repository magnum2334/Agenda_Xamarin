using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using App1.Models;
using Xamarin.Forms;
using App1.ViewModel;
using App1.Views;

namespace App1.ViewModel
{
    class LoginViewModel : BaseViewModel
    {

        #region Atributos
        public string gmail;
        public string password;
        #endregion



        #region Prop

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

        #endregion


        #region Commands

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }
            set { }
        }

        #endregion


        #region Methods

        public async void LoginMethod()
        {

            List<User> ListUser = App.Db.ValidateUserModel(gmail, password).Result;

            User Usr = App.Db.GetUserModel(gmail, password).Result;


           
            if (ListUser.Count > 0)
            {
                await Application.Current.MainPage.DisplayAlert("WELCOME", "Bienvenido "+gmail +" Aplicacion ", "OK");
                await Application.Current.MainPage.Navigation.PushAsync(new Home());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("ERROR", "Usuario o Contraseña  Incorrecta...", "OK");
            }
        }

        #endregion



    }
}
