using System;
using System.Collections.Generic;

namespace PenaltyCalculation.Models
{
    public partial class Holidaycalendar
    {
        public short Id { get; set; }
        public DateTime? Holidaydate { get; set; }
        public DateTime? Lastupdateddate { get; set; }
        public int Cid { get; set; }
        public DateTime? Createdon { get; set; }
        public string? Createdby { get; set; }
        public DateTime? Lastupdatedon { get; set; }
        public string? Lastupdatedby { get; set; }

        public virtual Country CidNavigation { get; set; } = null!;
    }
}
