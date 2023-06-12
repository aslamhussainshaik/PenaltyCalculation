using System;
using System.Collections.Generic;

namespace PenaltyCalculation.Models
{
    public partial class Logger
    {
        public Logger()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime Accessdate { get; set; } // DateOnly
        public string Accesspage { get; set; } = null!;
        public DateTime? Createdon { get; set; }
        public string? Createdby { get; set; }
        public DateTime? Lastupdatedon { get; set; }
        public string? Lastupdatedby { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
