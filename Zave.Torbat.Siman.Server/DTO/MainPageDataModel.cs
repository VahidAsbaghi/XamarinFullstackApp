using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Server.DTO
{
    public class MainPageDataModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LoadingCardNumber { get; set; }
        public string TerminalName { get; set; }
        public string PositionSetDate { get; set; }
        public string PositionNumber { get; set; }
        public string PermittedLoadCount { get; set; }
        public string BeforeYouCount { get; set; }
        public string DriverNegativePoints { get; set; }
        public string TruckNegativePoints { get; set; }
        public string TruckInsuranceDate { get; set; }
        public string TruckTechnicalVisitDate { get; set; }
        public string HealthCardDate { get; set; }
        public string SmartCardDate { get; set; }
        public string DrivingLicenseDate { get; set; }
        public bool TakeLoadAccess { get; set; }
        public bool IsLoadPreSelected { get; set; }
    }
}
