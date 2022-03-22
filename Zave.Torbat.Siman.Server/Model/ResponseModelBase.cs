using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Server.Model
{
    public class ResponseModelBase
    {
        public bool IsSuccessful { get; set; }
        public string Description { get; set; }
        public int HtmlResult { get; set; }
        
    }
}
