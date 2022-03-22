using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Java.Util;
using Xamarin.Essentials;
using Zave.Torbat.Siman.Co.Presentation;
using Zave.Torbat.Siman.Co.Presentation.Concretes;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Exception = System.Exception;
using Thread = Java.Lang.Thread;
using Timer = Java.Util.Timer;

namespace Zave.Torbat.Siman.Android
{
    [Activity(Label = "PhoneVerificationActivity")]
    public class PhoneVerificationActivity : AppCompatActivity,IPhoneVerificationView
    {
        private TextView _verificationCodeTextView;
        private TextView _timerTextView;
        private string _phoneNumber;
        private string _originalToken;
        private int _forceInterruptThread=0;
        public IPhoneVerificationPresenter Presenter { get; set; }
        public object ViewContext { get; set; }

        public string VerificationCode
        {
            get => _verificationCodeTextView.Text;
            set => _verificationCodeTextView.Text = value;
        }

        public string Timer
        {
            get => _timerTextView.Text;
            set => _timerTextView.Text = value;
        }
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            _phoneNumber = Intent.GetStringExtra("phone");
            SetContentView(Resource.Layout.PhoneVerificationView);
            _verificationCodeTextView = FindViewById<TextView>(Resource.Id.txtTokenCode);
            _timerTextView = FindViewById<TextView>(Resource.Id.txtRemainTime);
            var btnActivate = FindViewById<Button>(Resource.Id.btnActivate);
            btnActivate.Click += BtnActivate_Click;
            SetPresenter();

            _originalToken =await Presenter.GetAccessTokenAsync();
            Presenter.StartPhoneVerification(_phoneNumber, _originalToken);
        }

        private void BtnActivate_Click(object sender, EventArgs e)
        {
            Presenter.VerifyPhoneNumber(VerificationCode, _originalToken);
        }

        private void SetPresenter()
        {
            this.Presenter = new PhoneVerificationPresenter(MainActivity.ApplicationController);
            Presenter.View = this;
            ViewContext = this;
        }

        public void SendSmsSuccessful(int timeoutSeconds)
        {
            _forceInterruptThread = 0;
            Toast.MakeText(this,"پیام فعالسازی با موفقیت به شماره موبایل ثبت شده شما ارسال شد. لطفا کد فعالسازی را وارد نمایید",ToastLength.Long).Show();
            
            var task=Task.Factory.StartNew(() =>
            {
                while (timeoutSeconds != -1)
                {
                    if (Interlocked.CompareExchange(ref _forceInterruptThread,0,1)==1)
                    {
                        return;
                    }
                    DownTimeCounterTask(timeoutSeconds);
                    timeoutSeconds--;
                    Thread.Sleep(1000);
                }
                Presenter.LogOut();
            });
        }

        public void SendSmsFailed(string resultDescription)
        {
            Toast.MakeText(this, "عدم موفقیت در ارسال کد فعالسازی. لطفا مجددا تلاش نمایید.", ToastLength.Short).Show();
            Presenter.LogOut();
        }

        public void AuthenticateFailed()
        {
            Toast.MakeText(this, "خطای شناسایی کاربر. لطفا مجددا تلاش کنید.", ToastLength.Short).Show();
            Presenter.LogOut();
        }

        public void RetrySendToken()
        {
            Toast.MakeText(this, "کد وارد شده اشتباه میباشد. لطفا دوباره وارد کنید.",ToastLength.Short).Show();
            
        }

        public void RetryReceiveToken()
        {
            Toast.MakeText(this, "تلاش ناموفق. لطفا دوباره وارد شوید.", ToastLength.Short).Show();
            Presenter.LogOut();
        }
        private string SetTimerValue(int start)
        {
            int minutes = (start / 60);
            int seconds = (start % 60);
            return minutes + ":" + seconds;
        }

        public void DownTimeCounterTask(int timeoutSeconds)
        {
            RunOnUiThread(() =>
            {
                Timer = SetTimerValue(timeoutSeconds);

                if (timeoutSeconds == 0)
                {
                    Toast.MakeText(this, "زمان مجاز ورود کد به پایان رسید. لطفا دوباره تلاش کنید", ToastLength.Long).Show();
                }
            });
        }

        public async void VerificationDone()
        {
            Interlocked.Exchange(ref _forceInterruptThread, 1);
            var token = await Presenter.GetAccessTokenAsync();
            Presenter.VerificationDoneInView(token);
        }
    }
}