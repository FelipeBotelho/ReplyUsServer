using System.Threading.Tasks;
using Application.Features.QuestionFeatures.Commands;
using Application.Features.QuestionFeatures.Commands.CreateQuestion;
using Application.Features.QuestionFeatures.Commands.DeleteQuestion;
using Application.Features.QuestionFeatures.Queries;
using Application.Features.QuestionFeatures.Queries.GetAllQuestions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class QuestionController : BaseApiController
    {
        /// <summary>
        /// Creates a New Question.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateQuestionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all Questions.
        /// </summary>
        /// <returns></returns>
         // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllQuestionsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllQuestionsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        /// <summary>
        /// Deletes Question Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async  Task<ActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteQuestionCommand() { Id = id }));
        }
    }
}
