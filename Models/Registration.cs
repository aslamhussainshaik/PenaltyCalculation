using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PenaltyCalculation.Repos
{
    public class Registration
    {
        public short Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(20)]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last name")]
        [StringLength(20)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your email.")]
        [Display(Name = "Email Address")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; } = null!;
    }
}
