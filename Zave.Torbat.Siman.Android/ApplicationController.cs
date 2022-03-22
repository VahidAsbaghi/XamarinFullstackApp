using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
//using Android.Gms.Common;
//using Android.Gms.Common;
//using Android.Gms.Common.Apis;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Zave.Torbat.Siman.Co.Core;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.Services;
using Zave.Torbat.Siman.Co.Presentation;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;
using Exception = Java.Lang.Exception;

namespace Zave.Torbat.Siman.Android
{
    public class ApplicationController:IApplicationController
    {
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public IAuthenticationService AuthenticationService { get; }
        public IEncryptService EncryptService { get; }
        public IUserDataService UserDataService { get; }
        //public IPushNotifyService PushNotifyService { get; }
        public IApiService ApiService { get; }

        public ApplicationController(IAuthenticationService authenticationService,IEncryptService encryptService,IUserDataService userDataService,IApiService apiService)
        {
            //PushNotifyService = pushNotifyService;
            AuthenticationService = authenticationService;
            EncryptService = encryptService;
            UserDataService = userDataService;
            ApiService = apiService;
        }

        public void RunLoginView(object context)
        {
            var intent = new Intent((AppCompatActivity)context, typeof(LoginViewActivity));
            intent.SetFlags(ActivityFlags.NewTask
                            | ActivityFlags.ClearTask);
            ((AppCompatActivity)context).StartActivity(intent);
        }

        public void RunMainPageView(TruckViewModel truckViewModelObject,object context)
        {
            var intent = new Intent((AppCompatActivity)context, typeof(MainPageActivity));
            intent.PutExtra("userJsonObject",JsonConvert.SerializeObject(truckViewModelObject));
            ((AppCompatActivity)context).StartActivity(intent);
        }

        public void RunPhoneVerificationView(string userObjectPhoneNumber,object context)
        {
            var intent = new Intent((AppCompatActivity)context, typeof(PhoneVerificationActivity));
            intent.PutExtra("phone", userObjectPhoneNumber);
            ((AppCompatActivity)context).StartActivity(intent);
        }

        public async Task LogOutUser(object context)
        {
            var currentActivity = (AppCompatActivity) context;
            var originalToken = await GetAccessTokenAsync(context);
            var isSuccessful=await AuthenticationService.LogOut(originalToken);
            if (isSuccessful)
            {
                SecureStorage.Remove("access_token");
                RunLoginView(currentActivity);
            }
            else
            {
                //todo
            }

        }

        public async Task<string> GetAccessTokenAsync(object context)
        {
            var currentActivity = (AppCompatActivity)context;
            var tokenBack = await SecureStorage.GetAsync("access_token");
            if (string.IsNullOrEmpty(tokenBack))
            {
                return null;
            }
            var imeiCode = Settings.Secure.GetString(currentActivity.ContentResolver, Settings.Secure.AndroidId);
            var originalToken = EncryptService.DecryptToken(tokenBack, imeiCode);
            return originalToken;
        }

        public bool IsGooglePlayServicesAvailable()
        {
            //var resultCode =
            //    GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);

            //if resultCode = ConnectionResult.Success then
            //    HasGooglePlayServices
            //else
            //if GoogleApiAvailability.Instance.IsUserResolvableError resultCode then
            //GoogleApiAvailability.Instance.GetErrorString(resultCode) |> RequiresUser
            //else NoGooglePlayServices
            return true;
        }

        public void RunTakeLoadView(object context)
        {
            var intent = new Intent((AppCompatActivity)context, typeof(TakeLoadActivity));
            ((AppCompatActivity)context).StartActivity(intent);
        }

        public void RunLoadInfoView(object context)
        {
            var intent=new Intent((AppCompatActivity)context,typeof(LoadInfoActivity));
            ((AppCompatActivity)context).StartActivity(intent);
        }

        public async void SetTakeLoadEnableTime()
        {
            await SecureStorage.SetAsync("LoadEnableTime", DateTime.Now.ToString());
        }
        public async Task<string> GetTakeLoadEnableTime()
        {
            return await SecureStorage.GetAsync("LoadEnableTime");
        }
    }
}