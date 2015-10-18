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

        public async Task<IHttpActionResult> Get(int id)
        {
            using (var repository = new Repository<Questionary>())
            {
                var questionary = await repository.FindAsync(id);
                if (questionary == null)
                {
                    return NotFound();
                }

                var questionaryExtended = new QuestionaryExtendedDto
                {
                    Questionary = questionary,
                    MatchingFieldsCamelCase = new string[] {}
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