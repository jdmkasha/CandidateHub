using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CandidateHub.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }
       
        public int PhoneNo { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Email { get; set; }
        public int TimeInterval { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        [Required]
        public string Comment { get; set; } 
       
    }
}