using System.Threading.Tasks;
using Application.Features.QuestionFeatures.Commands;
using Application.Features.QuestionFeatures.Queries;
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
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all Questions.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllQuestionsQuery()));
        }
        /// <summary>
        /// Gets Question Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetQuestionByIdQuery { Id = id }));
        }
        /// <summary>
        /// Deletes Question Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteQuestionByIdCommand { Id = id }));
        }
        /// <summary>
        /// Updates the Question Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateQuestionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
