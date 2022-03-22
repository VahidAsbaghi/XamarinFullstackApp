using System.Collections.Generic;
using Zave.Torbat.Siman.Co.Core.Models;

namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface ILoginPresentation:IPresentation<ILoginView>
    {
        string Login(string userName, string password);
        string GetUserData(string token);
        List<string> GetUserPlaques(string token);
        string EncryptToken(string token, string imeiCode);
        string DecryptToken(string tokenBack, string imeiCode);
        void UserLoggedIn(TruckViewModel truckViewModelObject);
    }
}
