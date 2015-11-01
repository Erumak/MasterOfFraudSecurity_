using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using MasterOfFraudSecurity.Code;
using MasterOfFraudSecurity.Entities;
using MasterOfFraudSecurity.Models;

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
                await repository.AddAsync(questionary);
                return Ok();
            }
        }
    }
}