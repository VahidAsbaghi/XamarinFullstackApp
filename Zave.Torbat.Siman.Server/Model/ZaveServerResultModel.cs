using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Zave.Torbat.Siman.Server.Model
{
    public class ZaveServerResultModel:StatusCodeResult
    {
        public ZaveServerResultModel(int statusCode) : base(statusCode)
        {
        }
        public ErrorResult ErrorResult { get; set; }
        public string Description { get; set; }

        
    }

    public enum ErrorResult
    {
        UserNotFound,
        TruckNotFound,
        TruckTurnDeleted,
        CertificateDateExpired,
        HealthCardDateExpired,
        SmartCardDateExpired,
        TakeLoadIsNotPermitted,
        LoadSelectTimeout

    }
}
