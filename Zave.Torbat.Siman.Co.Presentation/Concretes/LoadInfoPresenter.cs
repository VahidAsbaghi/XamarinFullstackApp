using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.ResponseModels;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;

namespace Zave.Torbat.Siman.Co.Presentation.Concretes
{
    public class LoadInfoPresenter:ILoadInfoPresenter
    {
        public ILoadInfoView View { get; set; }
        public IApplicationController ApplicationController { get; }
       
        public LoadInfoPresenter(IApplicationController applicationController)
        {
            ApplicationController = applicationController;
        }

        public async void SetLoadInfo()
        {
            var token = await ApplicationController.GetAccessTokenAsync(View.ViewContext);
            IRestResponse loadInfoResult=await ApplicationController.ApiService.GetSelectedLoadInfo(token);
            if (!loadInfoResult.IsSuccessful)
            {
                //todo inform the view about unsuccessful result
                View.GetLoadInfoFailed();
                return;
                
            }

            var loadInfoData = JsonConvert.DeserializeObject<LoadInfoDataModel>(loadInfoResult.Content);
            View.ProductName = loadInfoData.Product;
            View.LoadType = loadInfoData.LoadingType;
            View.DestinationAddress = loadInfoData.DestinationAddress;
            View.LoadWeight = loadInfoData.Weight;

        }
        public void SetApplicationHeader()
        {
            View.FullName = ApplicationController.FullName;
            View.CardNumber = ApplicationController.CardNumber;
        }

        public async void TakeTurn()
        {
            //var token = await ApplicationController.GetAccessTokenAsync(View.ViewContext);
            //var result=await ApplicationController.ApiService.TakeTurnAsync(token);
            //if (result.IsSuccessful)
            //{
            //    var currentPosition = int.Parse(JsonConvert.DeserializeObject<string>(result.Content));
            //    View.ShowTakenTurn(currentPosition);
            //    UnSubscribeGetPosition();
            //    _getPositionThread = SubscribeToReceivePosition();
            //}
        }

        public async void CancelTurn()
        {
            var token = await ApplicationController.GetAccessTokenAsync(View.ViewContext);
            var response = await ApplicationController.ApiService.CancelTurnAsync(token);
            if (response.IsSuccessful)
            {
                View.CancelTurnSuccessful();
                ApplicationController.RunMainPageView(new TruckViewModel(), View.ViewContext);
            }
            else
            {
                //todo maybe logout
                ApplicationController.RunMainPageView(new TruckViewModel(), View.ViewContext);
            }
        }

        public void Logout()
        {
            ApplicationController.LogOutUser(View.ViewContext);
        }
    }
}
