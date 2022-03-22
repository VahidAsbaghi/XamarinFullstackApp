using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Org.Apache.Commons.Logging;
using Zave.Torbat.Siman.Co.Core;
using Zave.Torbat.Siman.Co.Core.Services;
using Zave.Torbat.Siman.Co.Presentation;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;
using IAuthenticationService = Zave.Torbat.Siman.Co.Core.Services.IAuthenticationService;

namespace Zave.Torbat.Siman.Android
{
    [Activity(Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity,IMainView
    {
        public IMainPresentation Presenter { get; set; }
        public object ViewContext { get; set; }
        public static IApplicationController ApplicationController;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            ViewContext = this;

            IApiService apiService=new ApiService();
            IAuthenticationService authenticationService=new AuthenticationService(apiService);
            IUserDataService userDataService=new UserDataService(authenticationService,apiService);
            //IPushNotifyService pushNotifyService=new PushNotifyService();
            ApplicationController = new ApplicationController(authenticationService,new EncryptService(),userDataService,apiService);

            var accessToken = await ApplicationController.GetAccessTokenAsync(this);

            if (string.IsNullOrEmpty(accessToken))
            {
                ApplicationController.RunLoginView(this);
                return;
            }

            //await ApplicationController.LogOutUser(this.ViewContext);
            var user = ApplicationController.UserDataService.GetUserProfile(accessToken);
            if (user == null)
            {
                ApplicationController.RunLoginView(this);
            }
            //todo phone confirmation 
            else //if (user.PhoneNumberConfirmed)
            {
                ApplicationController.FullName = user.DriverName;
                ApplicationController.CardNumber = user.CardNumber;
                ApplicationController.RunMainPageView(user,this);
            }
            //else
            //{
            //    ApplicationController.RunLoginView(this);
            //}

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }


        public void RunActivity()
        {
            var intent = new Intent(this, typeof(LoginViewActivity));
            StartActivity(intent);
            
        }

        public void WaitRunActivity()
        {
            throw new System.NotImplementedException();
        }
    }
}