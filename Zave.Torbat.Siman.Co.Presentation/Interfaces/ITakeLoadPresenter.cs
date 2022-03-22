using System;
using System.Collections.Generic;
using System.Text;
using Zave.Torbat.Siman.Co.Core.Models;

namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface ITakeLoadPresenter:IPresentation<ITakeLoadView>
    {
        void GetTownsList();
        void GetLoadsData(string selectedTowName);
        void Logout(object context);
        void CancelTurn();
        void LoadSelected(Load selectedItem);
        void SetApplicationHeader();
    }
}
