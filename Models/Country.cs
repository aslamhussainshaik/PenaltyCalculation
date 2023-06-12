using System;
using System.Collections.Generic;

namespace PenaltyCalculation.Models
{
    public partial class Country
    {
        public Country()
        {
            Holidaycalendars = new HashSet<Holidaycalendar>();
            Transactions = new HashSet<Transaction>();
        }

        public int Countryid { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Createdon { get; set; }
        public string? Createdby { get; set; }
        public DateTime? Lastupdatedon { get; set; }
        public string? Lastupdatedby { get; set; }

        public virtual ICollection<Holidaycalendar> Holidaycalendars { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
