using DayCount.Model;
using DayCount.View;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DayCount.ViewModel
{
    class EventDataViewModel : BindableObject, INotifyPropertyChanged
    {
        private ObservableCollection<EventDataModel> _DayEventModel = new ObservableCollection<EventDataModel>();
        public ObservableCollection<EventDataModel> DayEventModel
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

        private SettingDataModel _SettingDataModel = new SettingDataModel();
        public string DayCount
        {
            get
            {
                return _SettingDataModel.DayCount;
            }
            set
            {
                _SettingDataModel.DayCount = value;
                OnPropertyChanged(nameof(DayCount));
            }
        }
        public string StartDay
        {
            get
            {
                return _SettingDataModel.StartDay;
            }
            set
            {
                _SettingDataModel.StartDay = value;
                OnPropertyChanged(nameof(StartDay));
            }
        }


        public ICommand SettingTap { get; set; }
        public ICommand OneDayCheck { get; set; }

        public EventDataViewModel()
        {
            DayEventModel = new ObservableCollection<EventDataModel>();
            DayCount = _SettingDataModel.DayCount;
            StartDay = _SettingDataModel.StartDay;
            SetDayCntText(false);
            SettingTap = new Command(() => SetSettingStartDay());
            //OneDayCheck = new Command((e) => SetDayCntText(e));
        }
        private void SetSettingStartDay()
        {
            PopupNavigation.Instance.PushAsync(new SetStartDayPopup());
            //string result = await DisplayPromptAsync("Question 2", "What's 5 + 5?", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);
        }
        public void SetDayCntText(bool oneDayCheck)
        {
            DayEventModel.Clear();
            start("", "", "");
            string _StartString = "2020-10-07";
            StartDay = _StartString;

            DateTime StartStrDay = DateTime.Parse(_StartString); //시작날짜
            DateTime toDay = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")); //현재 날짜
            TimeSpan span = toDay - StartStrDay;
            int dayCnt = span.Days; //시작날짜로 부터 몇일이 지났는지
            if (oneDayCheck) dayCnt++; //1일부터 라면 +1
            DayCount = dayCnt.ToString();
            System.Diagnostics.Debug.WriteLine(oneDayCheck + ","+dayCnt +" , "+ StartStrDay.AddDays(dayCnt).ToString("yyyy-MM-dd"));


            int _ToDayEvent = dayCnt % 100; //최근 기념일 제외한 나머지
            string EventDay; //몇일 기념
            string EventName; //기념일 이름
            string EventD_Day; //기념일까지 남은 일수
            for (int i = _ToDayEvent; i <2000; i++, dayCnt++)
            {
                EventDay = StartStrDay.AddDays(dayCnt).ToString("yyyy-MM-dd"); //하루씩 더하여 지금이 이벤트인지 확인
                DateTime _EventDay = DateTime.Parse(EventDay); 
                span = _EventDay - toDay; //검사할 날짜와 지금 날짜를 빼서 DDay를 구한다.
                int DDayTmp = span.Days;
                if (oneDayCheck) DDayTmp--; //1일부터 라면 D-Day는 -1
                EventD_Day = DDayTmp.ToString();


                if (dayCnt % 100 == 0) //100일 단위 이벤트 이다.
                {
                    EventName = (dayCnt) + " 일";
                    start(EventDay, EventName, EventD_Day);
                }
                else if(StartStrDay.ToString("MM-dd") == StartStrDay.AddDays(dayCnt).ToString("MM-dd"))
                {
                    int YearEvent = Convert.ToInt32(StartStrDay.AddDays(dayCnt).ToString("yyyy")) -  Convert.ToInt32(StartStrDay.ToString("yyyy"));
                    EventName = YearEvent+"주 년";
                    start(EventDay, EventName, EventD_Day);
                }
                else if(dayCnt <100) //100일 이하
                {
                    if(dayCnt==22)
                    {
                        EventName = "22 데이";
                        start(EventDay, EventName, EventD_Day);
                    }
                    else if(dayCnt == 50)
                    {
                        EventName = (dayCnt) + " 일";
                        start(EventDay, EventName, EventD_Day);
                    }
                }
                else
                {
                    string _dayCntStr = dayCnt.ToString();
                    int len = _dayCntStr.Length;
                    for (int ii = 1; ii < len; ii++) //3333일같은 스트레이드 이벤트
                    {
                        if (_dayCntStr[ii - 1] != _dayCntStr[ii]) break;
                        else if (ii == len - 1)
                        {
                            EventName = (dayCnt) + " 일";
                            span = _EventDay - toDay; //이벤트 날짜와 지금 날짜를 빼서 DDay를 구한다.
                            EventD_Day = span.Days.ToString();
                            start(EventDay, EventName, EventD_Day);
                        }
                    }
                }
            }
           
        }
        private void start(string EventDay, string EventName, string EventD_Day)
        {
            DayEventModel.Add(new EventDataModel()
            {
                EventDay = EventDay,
                EventDDay = EventD_Day,
                EventName = EventName
            }) ;
        }
    }
}
