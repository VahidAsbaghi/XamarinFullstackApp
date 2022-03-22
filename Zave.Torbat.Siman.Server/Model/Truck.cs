using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Server.Model
{
    public class Truck
    {
        public int Id { get; set; }
        public string InsuranceDate { get; set; }
        public string TechnicalVisitDate { get; set; }
        public int NegativePoints { get; set; }
        public string PositionSetDate { get; set; }
        public string TerminalName { get; set; }
        public int PositionNumber { get; set; }
        public int PermittedLoadCount { get; set; }
        

        public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual User User { get; set; }

    }
}
