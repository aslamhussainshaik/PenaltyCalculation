using System;
using System.Collections.Generic;

namespace PenaltyCalculation.Models
{
    public partial class Securitypenaltyrate
    {
        public Securitypenaltyrate()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Securitypenaltyid { get; set; }
        public DateTime? Validfrom { get; set; } // DateOnly
        public decimal? Penaltyrate { get; set; }
        public DateTime? Lastupdateddate { get; set; } // DateOnly
        public DateTime? Createdon { get; set; }
        public string? Createdby { get; set; }
        public DateTime? Lastupdatedon { get; set; }
        public string? Lastupdatedby { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
