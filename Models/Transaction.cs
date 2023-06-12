using System;
using System.Collections.Generic;

namespace PenaltyCalculation.Models
{
    public partial class Transaction
    {
        public int Placeofholdingtechnumber { get; set; }
        public string Isin { get; set; } = null!;
        public int Securityquantity { get; set; }
        public string Transactiontypecode { get; set; } = null!;
        public string Instructiontypecode { get; set; } = null!;
        public string Matchingreference { get; set; } = null!;
        public DateTime Settlementdate { get; set; } // DateOnly
        public string Placeofsettlement { get; set; } = null!;
        public decimal Settlementcashamount { get; set; }
        public string Calendarid { get; set; } = null!;
        public string Partyid { get; set; } = null!;
        public string Counterpartyid { get; set; } = null!;
        public string Partyrolecd { get; set; } = null!;
        public string Counterpartyrolecd { get; set; } = null!;
        public string Failingpartyrolecd { get; set; } = null!;
        public decimal Penaltyamount { get; set; }
        public string? Sign { get; set; }
        public int Securitypriceid { get; set; }
        public int Securitypenaltyid { get; set; }
        public int Countryid { get; set; }
        public DateTime? Createdon { get; set; }
        public string? Createdby { get; set; }
        public DateTime? Lastupdatedon { get; set; }
        public string? Lastupdatedby { get; set; }
        public int LoggerId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual Logger Logger { get; set; } = null!;
        public virtual Securitypenaltyrate Securitypenalty { get; set; } = null!;
        public virtual Securityprice Securityprice { get; set; } = null!;
    }
}
