using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.RequestModels;
using Zave.Torbat.Siman.Co.Core.ResponseModels;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;

namespace Zave.Torbat.Siman.Co.Presentation.Concretes
{
    public class PhoneVerificationPresenter:IPhoneVerificationPresenter
    {
        public IPhoneVerificationView View { get; set; }
        public IApplicationController ApplicationController { get; }
        private StartPhoneVerificationResult PhoneVerificationResult { get; set; }
        
        public PhoneVerificationPresenter(IApplicationController applicationController)
        {
            ApplicationController = applicationController;
        }

        public string DecryptToken(string tokenBack, string imeiCode)
        {
            return ApplicationController.EncryptService.DecryptToken(tokenBack, imeiCode);
        }

        public async void VerifyPhoneNumber(string verificationCode, string originalToken)
        {
            var requestModel = new TokenMobileVerificationRequestModel()
            {
                ExpirationTime = PhoneVerificationResult.ExpirationTime, RequestCount = 1,
                VerifyToken = verificationCode
            };
            var response=await ApplicationController.AuthenticationService.ConfirmPhone(requestModel, originalToken);
            if (response.IsSuccessful)
            {
                View.VerificationDone();
            }
            else
            {
                switch (response.Description)
                {
                    case ResponseDescriptions.UserNotFound:
                        View.AuthenticateFailed();
                        break;
                    case ResponseDescriptions.InvalidModelState:
                        View.AuthenticateFailed();
                        break;
                    case ResponseDescriptions.InvalidVerificationToken:
                        View.RetrySendToken();
                        break;
                    case ResponseDescriptions.MaxRequestExceed:
                        View.RetryReceiveToken();
                        break;
                    case ResponseDescriptions.VerificationTokenExpired:
                        View.RetryReceiveToken();
                        break;
                }
            }
        }

        public async void StartPhoneVerification(string phoneNumber, string originalToken)
        {
            PhoneVerificationResult = await ApplicationController.AuthenticationService.StartPhoneConfirmation(phoneNumber, originalToken);
            if (PhoneVerificationResult.IsSuccessful)
            {
                View.SendSmsSuccessful(PhoneVerificationResult.TimeOutSeconds);
            }
            else
            {
                View.SendSmsFailed(PhoneVerificationResult.Description);
            }
             
        }

        public void LogOut()
        {
            ApplicationController.LogOutUser(View.ViewContext);
        }

        public void VerificationDoneInView(string token)
        {
            var user=ApplicationController.UserDataService.GetUserProfile(token);
            ApplicationController.RunMainPageView(user,View.ViewContext);
        }

        public Task<string> GetAccessTokenAsync()
        {
            return ApplicationController.GetAccessTokenAsync(View.ViewContext);
        }
    }
}
