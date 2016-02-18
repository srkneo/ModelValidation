using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class Appointment
    {
        [Required]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage="Please Enter a Date")]
        public DateTime Date { get; set; }

        [Range(typeof(bool),"true","true",ErrorMessage = "you must accept the terms")]
        public bool TermAccepted { get; set; }
    }
}