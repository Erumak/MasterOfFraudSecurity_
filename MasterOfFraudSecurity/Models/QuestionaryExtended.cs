using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterOfFraudSecurity.Entities;

namespace MasterOfFraudSecurity.Models
{
    public class QuestionaryExtended
    {
        public Questionary Questionary { get; set; }
        public ICollection<MatchingField> MatchingFields { get; set; } 
    }
}