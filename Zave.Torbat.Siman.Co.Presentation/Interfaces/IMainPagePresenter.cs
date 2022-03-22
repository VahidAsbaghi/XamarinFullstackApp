using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface IMainPagePresenter:IPresentation<IMainPageView>
    {
        void SetViewItems(string userData);
        Thread SubscribeToReceivePosition();
        void ShowTakeLoadView();
        void Logout(object context);
        void TakeTurn();
        void EnableTakeLoad();
        void SetApplicationHeader();
    }
}
