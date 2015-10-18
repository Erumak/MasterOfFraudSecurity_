using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterOfFraudSecurity.Entities;

namespace MasterOfFraudSecurity.Code
{
    public class QuestionaryMatchingFieldService
    {
        private readonly ApplicationDbContext _context;

        public QuestionaryMatchingFieldService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<string> GetMatchingFields(Questionary questionary)
        {
            throw new NotImplementedException();
        } 
    }
}