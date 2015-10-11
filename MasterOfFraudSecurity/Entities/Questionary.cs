using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterOfFraudSecurity.Entities
{
    public class Questionary
    {
        public Questionary()
        {
            CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Patronimic { get; set; }
        public DateTime BirthDay { get; set; }
        [Required]
        [MaxLength(12)]
        public string MobilePhone { get; set; }
        [EmailAddress]
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(2)]
        [MinLength(2)]
        public string PassportSeries { get; set; }
        [Required]
        [MaxLength(6)]
        [MinLength(6)]
        public string PassportNumber { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string IINPhysic { get; set; }
        public string PassportIssued { get; set; }
        public string AddressLocation { get; set; }
    }

}