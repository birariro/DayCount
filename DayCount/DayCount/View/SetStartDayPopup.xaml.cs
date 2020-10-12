using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DayCount.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetStartDayPopup 
    {
        public SetStartDayPopup()
        {
            InitializeComponent();
        }

        private void SetDay_Clicked(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.PopAsync(true);
            string StartYear = UserStartYear.Text;
            string Startmonth = UserStartmonth.Text;
            string Startdate = UserStartdate.Text;
            bool userFlag = UserStartOneDayCheck.IsChecked;
            //Preferences.Get();

            System.Diagnostics.Debug.WriteLine(StartYear);
            System.Diagnostics.Debug.WriteLine(Startmonth);
            System.Diagnostics.Debug.WriteLine(Startdate);
            System.Diagnostics.Debug.WriteLine(userFlag);
        }
    }
}