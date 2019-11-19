﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace Countdown.ViewModel
{
    public class CountDownViewModel : ViewModelBase
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        private TimeSpan BaseCountDownTime { get; set; } = new TimeSpan(0, 0, 0);
        private readonly TimeSpan _timeSpanZero = new TimeSpan(0, 0, 0);

        public CountDownViewModel()
        {
            StartCommand = new RelayCommand(OnStartCommand);
            StopCommand = new RelayCommand(OnStopCommand);
            ResetCommand = new RelayCommand(OnResetCommand);

            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += _timer_Tick;
        }

        public TimeSpan CountDownTime
        {
            get => _countDownTime;
            set => Set(ref _countDownTime, value);
        }
        private TimeSpan _countDownTime = new TimeSpan(0, 0, 0);

        public bool IsTimeNegative
        {
            get =>  _IsTimeNegative;
            set => Set(ref _IsTimeNegative, value);
        }
        private bool _IsTimeNegative;

        public ICommand ResetCommand { get; }
        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }
       
        public double Value
        {
            get => _value;
            set => Set(ref _value, value);
        }
        private double _value;

        private void OnResetCommand()
        {
            _timer.Stop();
            CountDownTime = BaseCountDownTime;
            _timer.Start();
        }

        private void OnStopCommand()
        {
            _timer.Stop();
        }

        private void OnStartCommand()
        {
            _timer.Start();
            BaseCountDownTime = CountDownTime;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            Value = 100 - (CountDownTime.TotalSeconds / BaseCountDownTime.TotalSeconds) * 100;
            CountDownTime = CountDownTime.Subtract(new TimeSpan(0, 0, 1));
            
            if(CountDownTime < _timeSpanZero)
            {
                IsTimeNegative = true;
            }
        }
    }
}
