using System;
using System.Collections.Generic;

namespace PenaltyCalculation.Models
{
    public partial class Securityprice
    {
        public Securityprice()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Securitypriceid { get; set; }
        public string IsinSecId { get; set; } = null!;
        public DateTime? ValidFromDate { get; set; } // DateOnly
        public decimal Securityprice1 { get; set; }
        public DateTime? Createdon { get; set; }
        public string? Createdby { get; set; }
        public DateTime? Lastupdatedon { get; set; }
        public string? Lastupdatedby { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
