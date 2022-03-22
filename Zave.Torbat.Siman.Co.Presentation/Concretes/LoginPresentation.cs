using System.Collections.Generic;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;

namespace Zave.Torbat.Siman.Co.Presentation.Concretes
{
    public class LoginPresentation:ILoginPresentation
    {
        public ILoginView View { get; set; }
        public IApplicationController ApplicationController { get; }

        public LoginPresentation(IApplicationController applicationController)
        {
            ApplicationController = applicationController;
        }

        public string Login(string userName, string password)
        {
           return ApplicationController.AuthenticationService.Login(new Credentials()
                {CardNumber = userName, NationalId = password});
        }

        public string GetUserData(string token)
        {
            return ApplicationController.AuthenticationService.GetUser(token);
        }

        public List<string> GetUserPlaques(string token)
        {
            return null; //ApplicationController.AuthenticationService.GetUserPlaques(token);
        }

        public string EncryptToken(string token, string imeiCode)
        {
            return ApplicationController.EncryptService.EncryptToken(token, imeiCode);
        }

        public string DecryptToken(string tokenBack, string imeiCode)
        {
            return ApplicationController.EncryptService.DecryptToken(tokenBack, imeiCode);
        }

        public void UserLoggedIn(TruckViewModel truckViewModelObject)
        {
            //todo phone confirmation
            //if (truckViewModelObject.PhoneNumberConfirmed)
            {
                ApplicationController.RunMainPageView(truckViewModelObject,View.ViewContext);
            }
           // else
            //{
              //  ApplicationController.RunPhoneVerificationView(truckViewModelObject.PhoneNumber,View.ViewContext);
            //}
        }
    }
}
