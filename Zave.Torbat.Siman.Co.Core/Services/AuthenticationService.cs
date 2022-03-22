using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.RequestModels;
using Zave.Torbat.Siman.Co.Core.ResponseModels;

namespace Zave.Torbat.Siman.Co.Core.Services
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly IApiService _apiService;

        public AuthenticationService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public string Login(Credentials credentials)
        {
            IRestResponse loginResponse = _apiService.GetLogin(credentials);
            string token = loginResponse.Content;
            return token;
        }

        public string GetUser(string token)
        {
            return _apiService.GetUser(token).Content;
        }

        public async Task<TokenMobileVerificationResponseModel> ConfirmPhone(TokenMobileVerificationRequestModel verifyToken,
            string token)
        {
            var response = await _apiService.ConfirmPhoneNumber(verifyToken,token);
            var result = response.Content;
            return JsonConvert.DeserializeObject<TokenMobileVerificationResponseModel>(response.Content); //new TokenMobileVerificationResponseModel();//todo set the values in result model according to response
        }

        public async Task<StartPhoneVerificationResult> StartPhoneConfirmation(string phoneNumber, string originalToken)
        {
            var response = await _apiService.StartPhoneConfirmation(phoneNumber, originalToken);
            return JsonConvert.DeserializeObject<StartPhoneVerificationResult>(response.Content);// new StartPhoneVerificationResult(){};
        }

        public async Task<bool> LogOut(string originalToken)
        {
            var response=await _apiService.LogOut(originalToken);
            return response.IsSuccessful;
        }

        public async Task<List<string>> GetUserPlaques(string token)
        {
            var response = await _apiService.GetPlaques(token);
            return JsonConvert.DeserializeObject<List<string>>(response.Content);
        }
    }
}
