using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterOfFraudSecurity.Entities;

namespace MasterOfFraudSecurity.Models
{
    public class QuestionaryExtendedDto
    {
        public Questionary Questionary { get; set; }
        public ICollection<string> MatchingFieldsCamelCase { get; set; } 
    }
}