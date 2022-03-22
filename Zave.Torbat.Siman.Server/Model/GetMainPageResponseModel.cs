using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zave.Torbat.Siman.Server.DTO;

namespace Zave.Torbat.Siman.Server.Model
{
    public class GetMainPageResponseModel:ResponseModelBase
    {
        public MainPageDataModel MainPageData { get; set; }
    }
}
