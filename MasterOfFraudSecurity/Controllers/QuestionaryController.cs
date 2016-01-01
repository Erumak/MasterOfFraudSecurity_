using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using MasterOfFraudSecurity.Code;
using MasterOfFraudSecurity.Entities;
using MasterOfFraudSecurity.Models;
using MasterOfFraudSecurity.Results;
using OfficeOpenXml;

namespace MasterOfFraudSecurity.Controllers
{
    public class QuestionaryController : ApiController
    {
        public async Task<Questionary[]> Get()
        {
            using (var repository = new Repository<Questionary>())
            {
                return await repository.GetAll().ToArrayAsync();
            }
        }

        [Route("api/questionary/suspicious")]
        [HttpGet]
        public async Task<Questionary[]> GetSuspicious()
        {
            using (var repository = new Repository<Questionary>())
            {
                return await new QuestionaryMatchingFieldService(repository).GetSuspiciousQuestionariesAsync();
            }
        }

        [Route("api/questionary/excelAll")]
        [HttpGet]
        public async Task<IHttpActionResult> ExcelDownloadAll()
        {
            using (var repository = new Repository<Questionary>())
            {
                var data = await repository.GetAll().ToArrayAsync();
                return new QuestionaryExcelFileActionResult(data, "all.xlsx");
            }
        }

        [Route("api/questionary/excelSuspicious")]
        [HttpGet]
        public async Task<IHttpActionResult> ExcelDownloadSuspicious()
        {
            using (var repository = new Repository<Questionary>())
            {
                var data = await new QuestionaryMatchingFieldService(repository).GetSuspiciousQuestionariesAsync();
                return new QuestionaryExcelFileActionResult(data, "suspicious.xlsx");
            }
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            using (var repository = new Repository<Questionary>())
            {
                var questionary = await repository.FindAsync(id);
                if (questionary == null)
                {
                    return NotFound();
                }

                var questionaryExtended = new QuestionaryExtended
                {
                    Questionary = questionary,
                    MatchingFields =
                        await new QuestionaryMatchingFieldService(repository).GetMatchingQuestionariesAsync(questionary)
                };

                return Ok(questionaryExtended);
            }
        }

        public async Task<IHttpActionResult> Post(Questionary questionary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var repository = new Repository<Questionary>())
            {
                repository.Add(questionary);
                await repository.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpPost]
        [Route("api/questionary/import")]
        public async Task<IHttpActionResult> PostExcelFile()
        {
            var stream = await Request.Content.ReadAsStreamAsync();

            IList<Questionary> questionaries;

            using (var package = new ExcelPackage(stream))
            {
                if (package.Workbook.Worksheets.Count == 0)
                {
                    throw new InvalidOperationException("Your Excel file does not contain any work sheets");
                }

                var worksheet = package.Workbook.Worksheets.First();

                questionaries = FromExcelSheet(worksheet);
            }

            if (questionaries.Count == 0)
            {
                throw new InvalidOperationException("Excel file is empty");
            }

            using (var repository = new Repository<Questionary>())
            {
                repository.DeleteAll();
                foreach (var questionary in questionaries)
                {
                    repository.Add(questionary);
                }
                await repository.SaveChangesAsync();
            }

            return Ok();
        }

        private static IList<Questionary> FromExcelSheet(ExcelWorksheet worksheet)
        {
            var list = new List<Questionary>();
            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var questionary = new Questionary
                {
                    LastName = worksheet.GetValue<string>(i, 3),
                    FirstName = worksheet.GetValue<string>(i, 4),
                    Patronymic = worksheet.GetValue<string>(i, 5),
                    BirthDate = worksheet.GetValue<DateTime>(i, 6),
                    MobilePhone = worksheet.GetValue<string>(i, 7),
                    Email = worksheet.GetValue<string>(i, 8),
                    PassportSeries = worksheet.GetValue<string>(i, 9),
                    PassportNumber = worksheet.GetValue<string>(i, 10),
                    IINPhysic = worksheet.GetValue<string>(i, 11),
                    PassportIssued = worksheet.GetValue<string>(i, 12),
                    AddressLocation = worksheet.GetValue<string>(i, 13)                
                };

                list.Add(questionary);
            }

            return list;
        }
    }
}