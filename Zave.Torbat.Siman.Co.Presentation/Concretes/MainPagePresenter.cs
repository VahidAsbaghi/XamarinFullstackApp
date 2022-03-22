using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xamarin.Essentials;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.ResponseModels;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;
using static System.Int32;

namespace Zave.Torbat.Siman.Co.Presentation.Concretes
{
    public class MainPagePresenter : IMainPagePresenter
    {
        public IMainPageView View { get; set; }
        public IApplicationController ApplicationController { get; }
        private string _accessToken = "";
        private Thread _getPositionThread;

        public MainPagePresenter(IApplicationController applicationController)
        {
            ApplicationController = applicationController;
            
        }
        public void SetViewItems(string userData)
        {
            ReadAccessToken();
           // var token = await ApplicationController.GetAccessTokenAsync(View.ViewContext);
            var responseModel = ApplicationController.UserDataService.GetMainPageDataModel(_accessToken);
            if (responseModel==null)
            {
                View.GetDataFailed(null);
            }
            else if (responseModel.IsSuccessful)
            {
                if (responseModel.MainPageData.IsLoadPreSelected)
                {
                    ApplicationController.RunLoadInfoView(View.ViewContext);
                }
                else
                {
                    SetViewProperties(responseModel);
                }
                
            }
            else
            {
                View.GetDataFailed(responseModel);
            }
        }

        public Thread SubscribeToReceivePosition()
        {
            //ReadAccessToken();
            Thread getPositionThread=new Thread(GetPositionThreadStart); 
            getPositionThread.Start();
            return getPositionThread;
        }

        private void GetPositionThreadStart(object obj)
        {
            var currentPosition = Parse(View.PositionNumber);

            while (currentPosition > 100)
            {
                Thread.Sleep(180000);
                currentPosition = GetPosition();
            }

            while (currentPosition > 50)
            {
                Thread.Sleep(60000);
                currentPosition = GetPosition();
            }

            while (currentPosition > 10)
            {
                Thread.Sleep(30000);
                currentPosition = GetPosition();
            }

            while (currentPosition != 1)
            {
                Thread.Sleep(2000);
                currentPosition = GetPosition();
            }
            
            
        }

        public void ShowTakeLoadView()
        {
            ApplicationController.RunTakeLoadView(View.ViewContext);
        }

        public void Logout(object context)
        {
            ApplicationController.LogOutUser(context);
        }

        public async void TakeTurn()
        {
            var turnResponse=await ApplicationController.ApiService.TakeTurnAsync(_accessToken);
            if (turnResponse.IsSuccessful)
            {
                var currentPosition = Parse(JsonConvert.DeserializeObject<string>(turnResponse.Content));
                View.ShowTakenTurn(currentPosition);
                UnSubscribeGetPosition();
                _getPositionThread=SubscribeToReceivePosition();
            }
        }

        public async void EnableTakeLoad()
        {
            var takeLoadPermittedResponse = await ApplicationController.ApiService.GetTakeLoadPermission(_accessToken);
            if (takeLoadPermittedResponse.IsSuccessful)
            {
                var takeLoadTimeOut = JsonConvert.DeserializeObject<int>(takeLoadPermittedResponse.Content);
                ApplicationController.SetTakeLoadEnableTime();
                View.NotifyUserTurn(takeLoadTimeOut);
                View.TakeLoadButtonEnabled = true;
            }
            else
            {
                View.TakeLoadNotPermitted();
            }
        }

        private int GetPosition()
        {
            var response = ApplicationController.ApiService.GetCurrentPosition(_accessToken);
            var currentPosition = 0;
            if (response.IsSuccessful)
            {
                currentPosition = Parse(JsonConvert.DeserializeObject<string>(response.Content));
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    View.PositionNumber = currentPosition.ToString();
                });
            }
            return currentPosition;
        }
        //ApplicationController.PushNotifyService.CreateHubConnection();
        private async void ReadAccessToken()
        {
            if (string.IsNullOrEmpty(_accessToken))
            {
                _accessToken = await ApplicationController.GetAccessTokenAsync(View.ViewContext);
            }
        }

        private void SetViewProperties(MainPageDataResponseModel responseModel)
        {
            //View.BeforeYouNumber = responseModel.MainPageData.BeforeYouCount;
            //View.TextBeforeYouCount = $"تعداد {responseModel.MainPageData.BeforeYouCount} راننده قبل از شما در صف هستند";
            View.TextDriverHealthCard = responseModel.MainPageData.HealthCardDate;
            View.TextDriverNegativePoints = $"شما {responseModel.MainPageData.DriverNegativePoints} امتیاز منفی دارید";
            View.TextDrivingLicense = responseModel.MainPageData.DrivingLicenseDate;
            View.TextPermittedLoad = responseModel.MainPageData.PermittedLoadCount;
            View.PositionNumber = responseModel.MainPageData.PositionNumber;
            View.TextPositionSetDate = responseModel.MainPageData.PositionSetDate;
            View.TextSmartCard = responseModel.MainPageData.SmartCardDate;
            View.TextTerminalName = responseModel.MainPageData.TerminalName;
            View.TextTruckInsuranceDate = responseModel.MainPageData.TruckInsuranceDate;
            View.TextTruckNegativePoints = $"کامیون شما {responseModel.MainPageData.TruckNegativePoints} امتیاز منفی دارد";
            View.TextTruckTechnicalHealth = responseModel.MainPageData.TruckTechnicalVisitDate;
            if (string.IsNullOrEmpty(responseModel.MainPageData.PositionNumber) || responseModel.MainPageData.PositionNumber=="-1")
            {
                View.TakeTurnButtonEnabled = true;
                View.TakeLoadButtonEnabled = false;
            }
            else
            {
                if (responseModel.MainPageData.PositionNumber!="1")
                {
                    UnSubscribeGetPosition();
                    _getPositionThread=SubscribeToReceivePosition();
                }
            }
        }

        private void UnSubscribeGetPosition()
        {
            if (_getPositionThread == null) return;
            _getPositionThread.Abort();
            _getPositionThread = null;
        }

        public void SetApplicationHeader()
        {
            View.FullName = ApplicationController.FullName;
            View.CardNumber = ApplicationController.CardNumber;
        }
    }
}
