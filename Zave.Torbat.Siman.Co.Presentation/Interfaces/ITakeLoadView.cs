using System;
using System.Collections.Generic;
using System.Text;
using Zave.Torbat.Siman.Co.Core.Models;

namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface ITakeLoadView:IView<ITakeLoadPresenter>
    {
        List<string> Towns { get; set; }
        List<Load> Loads { get; set; }
        void CancelTurnSuccessful();
        void TakeLoadTimeout();
        string FullName { set; }
        string CardNumber { set; }
    }
}
