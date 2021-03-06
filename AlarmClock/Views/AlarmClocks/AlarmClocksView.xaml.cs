﻿/*using System;
using System.Windows;
using System.Windows.Controls;
using AlarmClock.Models;
using AlarmClock.ViewModels.AlarmClocks;
using AlarmClock.ViewModels.AlarmClocks.AlarmClock;
using AlarmClock.Views.AlarmClocks.AlarmClockConfig;

namespace AlarmClock.Views.AlarmClocks
{
    /// <summary>
    /// Interaction logic for AlarmClocksView.xaml
    /// </summary>
    public partial class AlarmClocksView : UserControl
    {
        private AlarmClocksViewModel _alarmClocksViewModel;

        public AlarmClocksView()
        {   
            InitializeComponent();
            Visibility = Visibility.Visible;
            _alarmClocksViewModel = new AlarmClocksViewModel(OnAlarmClockChanged);
            DataContext = _alarmClocksViewModel;
        }

        private void OnAlarmClockChanged(AlarmClockForView alarmClock)
        {
            if (AlarmClockView == null)
            {
                AlarmClockView = new AlarmClockView();
            }
            AlarmClockViewModel alarmClockViewModel = new AlarmClockViewModel(alarmClock);
            AlarmClockView.DataContext = alarmClockViewModel;
        }
    }
}
*/