using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterOfFraudSecurity.Entities;

namespace MasterOfFraudSecurity.Models
{
    public class QuestionaryDisplayDto
    {
        public QuestionaryDisplayDto()
        {
            
        }

        public QuestionaryDisplayDto(Questionary q)
        {
            Id = q.Id;
            DisplayName = $"{q.LastName} {q.FirstName} {q.Patronymic} (ID: {q.Id}, INN: {q.IINPhysic})";
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}