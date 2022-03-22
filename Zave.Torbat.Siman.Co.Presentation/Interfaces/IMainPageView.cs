using System;
using System.Collections.Generic;
using System.Text;
using Zave.Torbat.Siman.Co.Core.ResponseModels;

namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface IMainPageView:IView<IMainPagePresenter>
    {
        string TextTerminalName { get; set; }
        string TextPositionSetDate { get; set; }
        string TextPositionNumber { get; set; }
        string TextPermittedLoad { get; set; }
        //string TextBeforeYouCount { get; set; }
        string TextDriverNegativePoints { get; set; }
        string TextTruckNegativePoints { get; set; }
        string TextTruckInsuranceDate { get; set; }
        string TextTruckTechnicalHealth { get; set; }
        string TextDriverHealthCard { get; set; }
        string TextSmartCard { get; set; }
        string TextDrivingLicense { get; set; }
        string PositionNumber { get; set; }
        bool TakeTurnButtonEnabled { set; }
        bool TakeLoadButtonEnabled { set; }
        string FullName { set; }
        string CardNumber { set; }
        void GetDataFailed(MainPageDataResponseModel responseModel);
        void NotifyUserTurn(int takeLoadTimeOut);
        void ShowTakenTurn(int currentPosition);
        void TakeLoadNotPermitted();
    }
}
