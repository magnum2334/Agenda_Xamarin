using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateTask : ContentPage
    {
        public CreateTask()
        {
            InitializeComponent();
            BindingContext = new TaskViewModel();
        }
    }
}