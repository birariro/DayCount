using DayCount.Model;
using DayCount.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DayCount
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        bool oneDayCheck = true;
       EventDataViewModel EventDataViewModel = new EventDataViewModel();
        public MainPage()
        {
            InitializeComponent();
            
            BindingContext = EventDataViewModel;
            
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var check = sender as CheckBox;
            var vm = this.BindingContext as EventDataViewModel;
            vm.SetDayCntText(check.IsChecked);
        }
    }
  
 
}
