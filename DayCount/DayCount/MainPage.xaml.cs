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
        
        public MainPage()
        {
            InitializeComponent();

            setEventList();
            SetDayCntText();
            BindingContext = DayEventModel;
            
        }

        private ObservableCollection<DayEvent> _DayEventModel = new ObservableCollection<DayEvent>();
        public ObservableCollection<DayEvent> DayEventModel
        {
            
            get
            {
                return _DayEventModel;
            }
            set
            {
                _DayEventModel = value;
                OnPropertyChanged(nameof(DayEventModel));
            }
        }
        public void setEventList()
        {
            DayEventModel.Add(new DayEvent()
            {
                EventName = "1000",
                EventDay = "2020-10-10",
                EventDDay = "-8"
            });

        }
        private int _Dayday = 0;
        public int Dayday
        {
            get 
            {
                return  _Dayday;
            }
            set 
            {
                _Dayday = value;
                OnPropertyChanged(nameof(Dayday));
            }
            
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            setEventList();
        }
        private void SetDayCntText()
        {
            string tagData = "2020-9-05";

            DateTime tagDay = DateTime.Parse(tagData);
            DateTime toDay = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            TimeSpan span = toDay - tagDay;
            int day = span.Days;
            Dayday = day;
            System.Diagnostics.Debug.WriteLine(day);
            //DayCntText.Text = day.ToString();
        }
    }
    /*public class binder : BindableObject, INotifyPropertyChanged
    {
       public binder() { 
        setEventList();
        }

        private ObservableCollection<DayEvent> _DayEventModel = new ObservableCollection<DayEvent>();
        public ObservableCollection<DayEvent> DayEventModel
        {
            get
            {
                return _DayEventModel;
            }
            set
            {
                _DayEventModel = value;
                OnPropertyChanged(nameof(DayEventModel));
            }
        }
        public void setEventList()
        {
            DayEventModel.Add(new DayEvent()
            {
                EventName = "1000",
                EventDay = "2020-10-10",
                EventDDay = "-8"
            });

        }


    }*/
    public class DayEvent
    {
        public string EventName { get; set; }
        public string EventDay { get; set; }
        public string EventDDay { get; set; }
    }
}
