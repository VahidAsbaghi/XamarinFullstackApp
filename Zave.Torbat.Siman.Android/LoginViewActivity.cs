using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Presentation;
using Zave.Torbat.Siman.Co.Presentation.Concretes;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;

namespace Zave.Torbat.Siman.Android
{
    [Activity(Label = "LoginViewActivity", Theme = "@style/AppTheme")]
    public class LoginViewActivity : AppCompatActivity,ILoginView
    {
        private TextView _userNameTextView;
        private TextView _passwordTextView;

        public ILoginPresentation Presenter { get; set; }
        public object ViewContext { get; set; }

        public string UserName
        {
            get => _userNameTextView.Text;
            set => _userNameTextView.Text = value;
        }

        public string Password
        {
            get => _passwordTextView.Text;
            set => _passwordTextView.Text = value;
        }
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LoginView);
            global::Android.Runtime.ResourceIdManager.UpdateIdValues();
            _userNameTextView = FindViewById<TextView>(Resource.Id.txtUsername);
            _passwordTextView = FindViewById<TextView>(Resource.Id.txtPass);
            var LoginButton = FindViewById<Button>(Resource.Id.btnLogin);
            LoginButton.Click += LoginButton_Click;
            
            SetPresenter();
            
        }

        private void SetPresenter()
        {
            this.Presenter=new LoginPresentation(MainActivity.ApplicationController);
            Presenter.View = this;
            ViewContext = this;
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string token = Presenter.Login(UserName, Password);
            var imeiCode=Settings.Secure.GetString(this.ContentResolver, Settings.Secure.AndroidId);
            string savedToken = Presenter.EncryptToken(token, imeiCode);

            // We check to see if we received an `id_token` and if we did make a secondary call
            // to get the user data. If we did not receive an `id_token` we can safely assume
            // that the authentication failed so we display an error message telling the user
            // to try again.
            if (token != null)
            {
               // SecureStorage.SetAsync("id_token", token.IdToken);
                await SecureStorage.SetAsync("access_token", savedToken);
            }
            else
            {
                //DisplayAlert("Oh No!", "It's seems that you have entered an incorrect email or password. Please try again.", "OK");
            };
            //Application.Current.Properties["id_token"] = token.id_token;
            var tokenBack = await SecureStorage.GetAsync("access_token");
            var originalToken = Presenter.DecryptToken(tokenBack,imeiCode);
            var user = Presenter.GetUserData(originalToken);
            var userObject = JsonConvert.DeserializeObject<TruckViewModel>(user);
            Presenter.UserLoggedIn(userObject);
            
        }

        public void Run()
        {
            
        }

        public void RunActivity()
        {
            throw new NotImplementedException();
        }


    }
}