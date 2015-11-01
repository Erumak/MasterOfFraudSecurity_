using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MasterOfFraudSecurity.Entities;
using MasterOfFraudSecurity.Models;

namespace MasterOfFraudSecurity.Code
{
    public class QuestionaryMatchingFieldService
    {
        private readonly Repository<Questionary> _repository;

        public QuestionaryMatchingFieldService(Repository<Questionary> repository)
        {
            _repository = repository;
        }

        public async Task<Questionary[]> GetSuspiciousQuestionariesAsync()
        {
            var questionaries = _repository.GetAll();
            return await _repository.GetAll()
                .Where(
                    q => questionaries.Any(questionary => q.Id != questionary.Id && (
                        q.IINPhysic == questionary.IINPhysic || q.Email == questionary.Email ||
                        q.MobilePhone == questionary.MobilePhone ||
                        q.PassportSeries == questionary.PassportSeries && q.PassportNumber == questionary.PassportNumber)))
                .ToArrayAsync();
        }

        public async Task<MatchingField[]> GetMatchingQuestionariesAsync(Questionary questionary)
        {
            var questionaries = await _repository.GetAll()
                .Where(
                    q => q.Id != questionary.Id && (
                        q.IINPhysic == questionary.IINPhysic || q.Email == questionary.Email ||
                        q.MobilePhone == questionary.MobilePhone ||
                        q.PassportSeries == questionary.PassportSeries && q.PassportNumber == questionary.PassportNumber))
                .ToArrayAsync();

            var iinMatches = new MatchingField
            {
                FieldName = "iinPhysic",
                Questionaries =
                    questionaries.Where(q => q.IINPhysic == questionary.IINPhysic)
                        .Select(q => new QuestionaryDisplayDto(q))
                        .ToArray()
            };

            var emailMatches = new MatchingField
            {
                FieldName = "email",
                Questionaries = questionaries.Where(q => q.Email == questionary.Email)
                    .Select(q => new QuestionaryDisplayDto(q)).ToArray()
            };

            var phoneMatches = new MatchingField
            {
                FieldName = "mobilePhone",
                Questionaries = questionaries.Where(q => q.MobilePhone == questionary.MobilePhone)
                    .Select(q => new QuestionaryDisplayDto(q)).ToArray()
            };

            var passportQuestionaries =
                questionaries.Where(
                    q =>
                        q.PassportSeries == questionary.PassportSeries && q.PassportNumber == questionary.PassportNumber)
                    .Select(q => new QuestionaryDisplayDto(q)).ToArray();

            var passportSeriesMatches = new MatchingField
            {
                FieldName = "passportSeries",
                Questionaries = passportQuestionaries
            };

            var passportNumberMatches = new MatchingField
            {
                FieldName = "passportNumber",
                Questionaries = passportQuestionaries
            };

            return
                new[] {iinMatches, phoneMatches, emailMatches, passportSeriesMatches, passportNumberMatches}.Where(
                    m => m.Questionaries.Any()).ToArray();
        }
    }
}