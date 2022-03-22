using System;
using System.Collections.Generic;
using System.Text;

namespace Zave.Torbat.Siman.Co.Core.Services
{
    public interface IEncryptService
    {
        string EncryptToken(string token, string key);
        string DecryptToken(string encryptedToken, string key);
    }
}
