using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;

namespace Zave.Torbat.Siman.Co.Presentation.Concretes
{
    public class TakeLoadPresenter:ITakeLoadPresenter
    {
        public ITakeLoadView View { get; set; }
        public IApplicationController ApplicationController { get; }
        public TakeLoadPresenter(IApplicationController applicationController)
        {
            ApplicationController = applicationController;
        }

        public async void GetTownsList()
        {
            var token = await ApplicationController.GetAccessTokenAsync(View.ViewContext);
            var response = await ApplicationController.ApiService.GetTownsAsync(token);
            View.Towns = JsonConvert.DeserializeObject<List<string>>(response.Content);
        }

        public async void GetLoadsData(string selectedTowName)
        {
            var token= await ApplicationController.GetAccessTokenAsync(View.ViewContext);
            var response = await ApplicationController.ApiService.GetLoadsDataAsync(token,selectedTowName);
            if(response.IsSuccessful && response.StatusCode==HttpStatusCode.OK)
                View.Loads = JsonConvert.DeserializeObject<List<Load>>(response.Content);
        }

        public void Logout(object context)
        {
            ApplicationController.LogOutUser(context);
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

        public async void LoadSelected(Load selectedItem)
        {
            var selectedLoad=JsonConvert.SerializeObject(selectedItem);
            var token = await ApplicationController.GetAccessTokenAsync(View.ViewContext);
            selectedItem.EnableTime = await ApplicationController.GetTakeLoadEnableTime() ?? DateTime.Now.ToString();
            var response=await ApplicationController.ApiService.LoadSelected(selectedLoad,token);
            if (response.IsSuccessful)
            {
                ApplicationController.RunLoadInfoView(View.ViewContext);
            }
            else
            {
                if (response.StatusCode==HttpStatusCode.NotAcceptable)
                {
                    View.TakeLoadTimeout();
                }
                //todo
            }
        }

        public void SetApplicationHeader()
        {
            View.FullName = ApplicationController.FullName;
            View.CardNumber = ApplicationController.CardNumber;
        }
    }
}
