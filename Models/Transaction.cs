using System;
using System.Collections.Generic;

namespace PenaltyCalculation.Repos
{
    public partial class Transaction
    {
        public int Placeofholdingtechnumber { get; set; }
        public string? Isin { get; set; }
        public int? Securityquantity { get; set; }
        public string? Transactiontypecode { get; set; }
        public string? Instructiontypecode { get; set; }
        public string? Matchingreference { get; set; }
        public DateTime? Settlement { get; set; } //DateOnly
        public decimal? Settlementcashamount { get; set; }
        public string? Calendarid { get; set; }
        public string? Partyid { get; set; }
        public string? Counterpartyid { get; set; }
        public string? Partyrolecd { get; set; }
        public string? Counterpartyrolecd { get; set; }
        public string? Failingpartyrolecd { get; set; }
        public decimal? Penaltyamount { get; set; }
        public string? Sign { get; set; }
    }
}
