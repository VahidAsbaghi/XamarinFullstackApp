using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.RequestModels;
using Zave.Torbat.Siman.Co.Core.ResponseModels;

namespace Zave.Torbat.Siman.Co.Core.Services
{
    public class ApiService : IApiService
    {
        private const string BaseAddress = "http://2.144.246.19:13129/api";//"http://10.0.2.2/Zave.Torbat.Siman.Server/api";//"";//"http://10.0.2.2/Zave.Torbat.Siman.Server/api";//"http://10.0.2.2:59285/api";//"http://78.38.134.2:13129/api";//;
        public IRestResponse GetLogin(Credentials credentials)
        {
            // We first create the request and add the necessary parameters
            var client = new RestClient(BaseAddress);
            var request = new RestRequest("account/login", Method.POST);
            request.AddJsonBody(credentials);
            // We execute the request and capture the response
            // in a variable called `response`
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse GetUser(string token)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("account/userData", token,Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public Task<IRestResponse> ConfirmPhoneNumber(TokenMobileVerificationRequestModel verificationTokenModel,
            string token)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("PhoneVerification/verify", token, Method.POST,JsonConvert.SerializeObject(verificationTokenModel));
            Task<IRestResponse> response = client.ExecuteAsync(request);
            return response;
        }

        public Task<IRestResponse> StartPhoneConfirmation(string phoneNumber, string originalToken)
        {
            var client = new RestClient(BaseAddress);
            var requestModel=new StartPhoneVerificationRequestModel(){ImeiCode = "",PhoneNumber = phoneNumber};
            var request = PrepareAuthorizedRequest("PhoneVerification/start", originalToken, Method.POST,JsonConvert.SerializeObject(requestModel));
            Task<IRestResponse> response = client.ExecuteAsync(request);
            return response;
        }

        public Task<IRestResponse> LogOut(string originalToken)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("account/logout", originalToken, Method.POST);
            Task<IRestResponse> response = client.ExecuteAsync(request);
            return response;
        }

        public IRestResponse GetMainPageData(string token)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("mainpage", token, Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse GetCurrentPosition(string token)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("mainpage/currentPosition", token, Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
        public Task<IRestResponse> TakeTurnAsync(string token)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("mainpage/takeTurn", token, Method.POST);
            var response = client.ExecuteAsync(request);
            return response;
        }

        public Task<IRestResponse> CancelTurnAsync(string token)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("mainpage/cancelTurn", token, Method.POST);
            Task<IRestResponse> response = client.ExecuteAsync(request);
            return response;
        }

        public Task<IRestResponse> GetTakeLoadPermission(string accessToken)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("mainpage/takeLoadPermitted", accessToken, Method.GET);
            Task<IRestResponse> response = client.ExecuteAsync(request);
            return response;
        }

        public Task<IRestResponse> GetPlaques(string token)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("account/getPlaques", token, Method.GET);
            var response = client.ExecuteAsync(request);
            return response;
        }

        public Task<IRestResponse> GetSelectedLoadInfo(string token)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("TakeLoad/selectedLoadInfo", token, Method.GET);
            var response = client.ExecuteAsync(request);
            return response;
        }

        public Task<IRestResponse> LoadSelected(string selectedLoad,string token)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("TakeLoad/loadSelected", token, Method.POST,selectedLoad);
            Task<IRestResponse> response = client.ExecuteAsync(request);
            return response;
        }

        

        public Task<IRestResponse> GetTownsAsync(string token)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("TakeLoad/getTowns", token, Method.GET);
            var response = client.ExecuteAsync(request);
            return response;
        }

        public Task<IRestResponse> GetLoadsDataAsync(string token, string selectedTowName)
        {
            var client = new RestClient(BaseAddress);
            var request = PrepareAuthorizedRequest("TakeLoad", token, Method.GET, parameter: selectedTowName,
                parameterName: "townName");
            var response = client.ExecuteAsync(request);
            return response;
        }

        


        private RestRequest PrepareAuthorizedRequest(string address,string token,Method method,string body=null,object parameter=null,string parameterName="")
        {
            var request = new RestRequest(address, method);
            if(body!=null)
                request.AddJsonBody(body);
            if (parameter != null)
                request.AddParameter(parameterName, parameter);
            token = token.Replace('"',' ').Trim();
            request.AddHeader("Authorization", "Bearer " 
                +token);
            return request;
        }
    }
}
