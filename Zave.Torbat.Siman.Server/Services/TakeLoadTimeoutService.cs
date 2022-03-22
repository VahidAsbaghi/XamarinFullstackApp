using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Server.Services
{
    public class TakeLoadTimeoutService:ITakeLoadTimeoutService
    {
        private int _timeOut;
        private int _timeCounter;
        private MyTimer _timer;
        //private readonly WaitHandle _waitHandle=new AutoResetEvent(false);
        private Action _onTimeout;

        public void NotifyTimeout(Action onTimeout)
        {
            _onTimeout = onTimeout;
        }

        public void Start(int timeOut)
        {
            _timeOut = timeOut;
            _timer = new MyTimer(1000, TimerTick);
            _timer.Start();
            //Stopwatch stopwatch=new Stopwatch();
            //stopwatch.Start();
            //_timer = new Timer(TimerTick, null, 0, 1000);
        }

        private void TimerTick()
        {

            //_timer.Change(Timeout.Infinite, 0);
            _timeCounter++;
            if (_timeCounter >= _timeOut)
            {
                Stop();
            }
            //_timer.Change(1000, 0);
        }

        public void Stop()
        {
           _timer.Stop();
        }

        public int RemainedTime()
        {
            return _timeOut - _timeCounter;
        }

        public bool IsTimeOut()
        {
            return _timer.IsStop();
        }
    }
}
