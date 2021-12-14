using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Views;
using App1.Data;
using App1.Models;
using System.IO;
using System.Collections.Generic;

namespace App1
{
    public partial class App : Application
    {
      
      
        static DatabaseContext database;
        public static DatabaseContext Db
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseContext(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.db"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Loginxamarin());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
