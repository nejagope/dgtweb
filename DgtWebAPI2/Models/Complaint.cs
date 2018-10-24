using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DgtWebApi2.Models
{
    public class Complaint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string EmailUser { get; set; }

        [Required]
        public DateTime? ComplaintDate { get; set; }

        [Required]
        public int ComplaintTypeId { get; set; }
        public ComplaintType ComplaintType { get; set; }
        
        
        public string PhoneUser { get; set; }
        public string Actions { get; set; }        
        public DateTime ActionsDate { get; set; }
        public bool Closed { get; set; }
        public DateTime CloseDate { get; set; } 
    }
}