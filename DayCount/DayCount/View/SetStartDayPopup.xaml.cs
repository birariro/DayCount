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
        TaskCompletionSource<bool> _tcs = null;
        public SetStartDayPopup()
        {
            InitializeComponent();
            UserStartYear.Text = Preferences.Get("StartYear", DateTime.Now.ToString("yyyy"));
            UserStartmonth.Text = Preferences.Get("Startmonth", DateTime.Now.ToString("MM"));
            UserStartdate.Text = Preferences.Get("Startdate", DateTime.Now.ToString("dd"));
            UserStartOneDayCheck.IsChecked = Preferences.Get("userFlag", false);
        }
        public async Task<bool> EndCheck()
        {
            _tcs = new TaskCompletionSource<bool>();

            return await _tcs.Task;
        }
        private void SetDay_Clicked(object sender, EventArgs e)
        {
            string StartYear = UserStartYear.Text;
            string Startmonth = UserStartmonth.Text;
            string Startdate = UserStartdate.Text;
            bool userFlag = UserStartOneDayCheck.IsChecked;

            if(Int32.TryParse(StartYear , out _) && Int32.TryParse(Startmonth, out _) && Int32.TryParse(Startdate, out _))
            {
                System.Diagnostics.Debug.WriteLine(StartYear);
                System.Diagnostics.Debug.WriteLine(Startmonth);
                System.Diagnostics.Debug.WriteLine(Startdate);
                System.Diagnostics.Debug.WriteLine(userFlag);
                Preferences.Set("StartYear", StartYear);
                Preferences.Set("Startmonth", Startmonth);
                Preferences.Set("Startdate", Startdate);
                Preferences.Set("userFlag", userFlag);
                Rg.Plugins.Popup.Services.PopupNavigation.PopAsync(true);
                _tcs?.SetResult(true);
            }
          
            
        }
    }
}