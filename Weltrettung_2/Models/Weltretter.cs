using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Weltrettung_2.Models
{
    public partial class Weltretter
    {
        [Required(ErrorMessage = "Bitte trage einen Vornamen ein")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Bitte trage einen Nachnamen ein")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Bitte trage ein Land ein")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Bitte trage eine Mail-Adresse ein")]
        public string Mail { get; set; }
        public string Skill { get; set; }
        public bool OfAge { get; set; }
        public bool Fraction { get; set; }
    }
}
