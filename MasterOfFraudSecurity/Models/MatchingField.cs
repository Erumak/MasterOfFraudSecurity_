using System.Collections.Generic;
using MasterOfFraudSecurity.Entities;

namespace MasterOfFraudSecurity.Models
{
    public class MatchingField
    {
        public string FieldName { get; set; }
        public ICollection<QuestionaryDisplayDto> Questionaries { get; set; }
    }
}