using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Zave.Torbat.Siman.Co.Core.ResponseModels;
using Zave.Torbat.Siman.Co.Presentation.Concretes;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;

namespace Zave.Torbat.Siman.Android
{
    [Activity(Label = "MainPageActivity")]
    public class MainPageActivity : AppCompatActivity,IMainPageView
    {
        private TextView _textViewTerminalName;
        private TextView _textViewPositionSetDate;
        private TextView _textViewPositionNumber;
        private TextView _textViewPermittedLoad;
        //private TextView _textViewBeforeYouCount;
        private TextView _textViewDriverNegativePoints;
        private TextView _textViewTruckNegativePoints;
        private TextView _textViewTruckInsuranceDate;
        private TextView _textViewTruckTechnicalHealth;
        private TextView _textViewDriverHealthCard;
        private TextView _textViewSmartCard;
        private TextView _textViewDrivingLicense;
        private Button _takeLoadButton;
        private Button _takeTurnButton;

        private string _beforeYouNumber = "";
        private Button _logoutButton;
        private TextView _nameText;
        private TextView _cardText;

        public string FullName
        {
            set => _nameText.Text = $"{value} گرامی خوش آمدید";
        }

        public string CardNumber
        {
            set =>_cardText.Text= $"شماره کارت بارگیری {value}";
        }

        public bool TakeTurnButtonEnabled
        {
            set => _takeTurnButton.Enabled = value;
        }

        public bool TakeLoadButtonEnabled
        {
            set => _takeLoadButton.Enabled = value;
        }
        public string TextTerminalName
        {
            get => _textViewTerminalName.Text;
            set => _textViewTerminalName.Text = value;
        }
        public string TextPositionSetDate
        {
            get => _textViewPositionSetDate.Text;
            set => _textViewPositionSetDate.Text = value;
        }
        public string TextPositionNumber
        {
            get => _textViewPositionNumber.Text;
            set => _textViewPositionNumber.Text = value;
        }
        public string TextPermittedLoad
        {
            get => _textViewPermittedLoad.Text;
            set => _textViewPermittedLoad.Text = value;
        }
        //public string TextBeforeYouCount
        //{
        //    get => _textViewBeforeYouCount.Text;
        //    set => _textViewBeforeYouCount.Text = value;
        //}
        public string TextDriverNegativePoints
        {
            get => _textViewDriverNegativePoints.Text;
            set => _textViewDriverNegativePoints.Text = value;
        }
        public string TextTruckNegativePoints
        {
            get => _textViewTruckNegativePoints.Text;
            set => _textViewTruckNegativePoints.Text = value;
        }
        public string TextTruckInsuranceDate
        {
            get => _textViewTruckInsuranceDate.Text;
            set => _textViewTruckInsuranceDate.Text = value;
        }
        public string TextTruckTechnicalHealth
        {
            get => _textViewTruckTechnicalHealth.Text;
            set => _textViewTruckTechnicalHealth.Text = value;
        }
        public string TextDriverHealthCard
        {
            get => _textViewDriverHealthCard.Text;
            set => _textViewDriverHealthCard.Text = value;
        }
        public string TextSmartCard
        {
            get => _textViewSmartCard.Text;
            set => _textViewSmartCard.Text = value;
        }
        public string TextDrivingLicense
        {
            get => _textViewDrivingLicense.Text;
            set => _textViewDrivingLicense.Text = value;
        }

        public string PositionNumber
        {
            get => _beforeYouNumber;
            set
            {
               TextPositionNumber= $"تعداد {value} راننده قبل از شما در صف هستند";
               _beforeYouNumber = value;
               if (value=="1")
               {
                   Presenter.EnableTakeLoad();
                  // NotifyUserTurn();
               }
            }
        }


        public IMainPagePresenter Presenter { get; set; }
        public object ViewContext { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            var userData = Intent.GetStringExtra("userJsonObject");
            SetContentView(Resource.Layout.MainPageView);
            BindControls();
            SetPresenter();
            Presenter.SetApplicationHeader();
            Presenter.SetViewItems(userData);
            //Presenter.SubscribeToReceivePosition();
        }
        public void GetDataFailed(MainPageDataResponseModel responseModel)
        {
            Toast.MakeText(this, responseModel?.Description, ToastLength.Long).Show();
        }

        public void NotifyUserTurn(int takeLoadTimeOut)
        {
            Toast.MakeText(this, $"نوبت بارگیری شما رسیده است لطفا در {takeLoadTimeOut} دقیقه اقدام فرمایید", ToastLength.Long).Show();
            //_takeLoadButton.Enabled = true;
        }

        public void ShowTakenTurn(int currentPosition)
        {
            Toast.MakeText(this, $"شماره نوبت شما {currentPosition} میباشد", ToastLength.Long).Show();
        }

        public void TakeLoadNotPermitted()
        {
            Toast.MakeText(this, "امکان بارگیری برای شما فراهم نمیباشد", ToastLength.Long).Show();
        }

        private void BindControls()
        {
            _textViewTerminalName = FindViewById<TextView>(Resource.Id.txtTerminalName);
            _textViewPositionSetDate=FindViewById<TextView>(Resource.Id.txtPositionSetDate);
            _textViewPositionNumber = FindViewById<TextView>(Resource.Id.txtPositionNumber);
            _textViewPermittedLoad = FindViewById<TextView>(Resource.Id.txtLoadPermittedCount);
            //_textViewBeforeYouCount = FindViewById<TextView>(Resource.Id.txtBeforeYouCount);
            _textViewDriverNegativePoints = FindViewById<TextView>(Resource.Id.txtDriverNegativePoints);
            _textViewTruckNegativePoints = FindViewById<TextView>(Resource.Id.txtTruckNegativePoints);
            _textViewTruckInsuranceDate = FindViewById<TextView>(Resource.Id.txtTruckInsDate);
            _textViewTruckTechnicalHealth = FindViewById<TextView>(Resource.Id.txtTruckTechnicalHealth);
            _textViewDriverHealthCard = FindViewById<TextView>(Resource.Id.txtDriverHealthCard);
            _textViewSmartCard = FindViewById<TextView>(Resource.Id.txtSmartCard);
            _textViewDrivingLicense = FindViewById<TextView>(Resource.Id.txtDrivingLicense);
            _nameText = FindViewById<TextView>(Resource.Id.nameMainPage);
            _cardText = FindViewById<TextView>(Resource.Id.cardMainPage);

            _takeLoadButton = FindViewById<Button>(Resource.Id.btnTakeLoad);
            _takeLoadButton.Click += _takeLoadButton_Click;

            _takeTurnButton = FindViewById<Button>(Resource.Id.btnTakeTurn);
            _takeTurnButton.Click += _takeTurnButton_Click;

            _logoutButton = FindViewById<Button>(Resource.Id.buttonLogout);
            _logoutButton.Click += _logoutButton_Click;
        }

        private void _takeTurnButton_Click(object sender, EventArgs e)
        {
            Presenter.TakeTurn();
        }

        private void _logoutButton_Click(object sender, EventArgs e)
        {
            Presenter.Logout(this);
        }

        private void _takeLoadButton_Click(object sender, EventArgs e)
        {
            Presenter.ShowTakeLoadView();
        }

        private void SetPresenter()
        {
            this.Presenter = new MainPagePresenter(MainActivity.ApplicationController);
            Presenter.View = this;
            ViewContext = this;
        }

        
    }
}