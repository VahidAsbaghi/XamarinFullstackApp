using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zave.Torbat.Siman.Server.Model
{
    public class Credentials
    {
        [JsonProperty("CardNumber")]
        public string CardNumber { get; set; }
        [JsonProperty("NationalId")]
        public string NationalId { get; set; }
    }
}
