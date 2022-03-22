using System;
using System.Collections.Generic;
using System.Text;

namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface ILoadInfoView : IView<ILoadInfoPresenter>
    {
        string LoadWeight { get; set; }
        string DestinationAddress { get; set; }
        string ProductName { get; set; }
        string LoadType { get; set; }
        void GetLoadInfoFailed();
        string FullName { set; }
        string CardNumber { set; }
        void CancelTurnSuccessful();
    }
}
