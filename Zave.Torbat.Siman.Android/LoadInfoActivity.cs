using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Zave.Torbat.Siman.Co.Presentation.Concretes;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;

namespace Zave.Torbat.Siman.Android
{
    [Activity(Label = "LoadInfoActivity")]
    public class LoadInfoActivity : AppCompatActivity,ILoadInfoView
    {
        private TextView _loadWeightText;
        private TextView _txtDestinationAddress;
        private TextView _productName;
        private ImageView _imageView;
        private string _loadType;
        private TextView _nameText;
        private TextView _cardText;
        private Button _cancelButton;
        private Button _takeTurnButton;
        private Button _logoutButton;

        public string FullName
        {
            set => _nameText.Text = $"{value} گرامی خوش آمدید";
        }

        public string CardNumber
        {
            set => _cardText.Text = $"شماره کارت بارگیری {value}";
        }

        public void CancelTurnSuccessful()
        {
            Toast.MakeText(this, "انصراف از بارگیری با موفقیت انجام شد", ToastLength.Long).Show();
        }

        public string LoadWeight
        {
            get => _loadWeightText.Text;
            set => _loadWeightText.Text = value;
        }

        public string DestinationAddress
        {
            get => _txtDestinationAddress.Text;
            set => _txtDestinationAddress.Text = value;
        }

        public string ProductName
        {
            get => _productName.Text;
            set => _productName.Text = value;
        }

        public string LoadType
        {
            get => _loadType;
            set
            {
                if (value == "کلینکر")
                {
                    _imageView.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.clinker));
                }
                else if (value == "بیگ بگ")
                {
                    _imageView.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.bigPacket));
                }
                else if (value == "پاکت")
                {
                    _imageView.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.packet));
                }

                _loadType = value;
            }
        }

        

        public ILoadInfoPresenter Presenter { get; set; }
        public object ViewContext { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LoadInfoView);
            BindControls();
            SetPresenter();
            Presenter.SetApplicationHeader();
            Presenter.SetLoadInfo();
        }
        public void GetLoadInfoFailed()
        {
            
        }
        private void BindControls()
        {
            _loadWeightText = FindViewById<TextView>(Resource.Id.txtLoadWeight);
            _txtDestinationAddress = FindViewById<TextView>(Resource.Id.txtDestinationAddress);
            _productName = FindViewById<TextView>(Resource.Id.txtObjectName);
            _nameText = FindViewById<TextView>(Resource.Id.NameLoadInfo);
            _cardText = FindViewById<TextView>(Resource.Id.cardLoadInfo);

            _imageView = FindViewById<ImageView>(Resource.Id.imageType);


            _logoutButton = FindViewById<Button>(Resource.Id.btnLogoutLoadInfo);
            _logoutButton.Click += _logoutButton_Click;
            //_cancelButton = FindViewById<Button>(Resource.Id.btnCancelTurnLoadInfo);
            //_cancelButton.Click += _cancelButton_Click;
            //_takeTurnButton = FindViewById<Button>(Resource.Id.btnTakeTurnLoadInfo);
            //_takeTurnButton.Click += _takeTurnButton_Click;

        }

        private void _logoutButton_Click(object sender, EventArgs e)
        {
            Presenter.Logout();
        }

        private void _takeTurnButton_Click(object sender, EventArgs e)
        {
            Presenter.TakeTurn();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            Presenter.CancelTurn();
        }

        private void SetPresenter()
        {
            this.Presenter = new LoadInfoPresenter(MainActivity.ApplicationController);
            Presenter.View = this;
            ViewContext = this;
        }

    }
}