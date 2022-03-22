using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Server.Services
{
    public class MyTimer
    {
        private readonly Thread _threadTimer;
        private readonly int _interval;
        private readonly Action _callback;
        private MyTimerState _state = MyTimerState.Stop;
        public MyTimer(int secondsInterval,Action callback)
        {
            _threadTimer = new Thread(TimerTick);
            _interval = secondsInterval;
            _callback = callback;
        }

        public void Start()
        {
            _threadTimer.Start();
            _state = MyTimerState.Active;
        }
        private void TimerTick(object obj)
        {
            Thread.Sleep(_interval);
            _callback();
            if (_state == MyTimerState.Stop)
            {
                return;
            }
            TimerTick(null);
        }

        public void Stop()
        {
            _threadTimer.Abort();
            _state = MyTimerState.Stop;
        }

        public bool IsStop()
        {
            return _state == MyTimerState.Stop;
        }
    }

    enum MyTimerState
    {
        Active,
        Stop
    }
}
