using System;
using System.Collections.Generic;
using System.Text;

namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface ILoadInfoPresenter:IPresentation<ILoadInfoView>
    {
        void SetLoadInfo();
        void SetApplicationHeader();
        void TakeTurn();
        void CancelTurn();
        void Logout();
    }
}
