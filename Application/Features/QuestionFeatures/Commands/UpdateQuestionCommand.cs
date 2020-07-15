using Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuestionFeatures.Commands
{
    public class UpdateQuestionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Values { get; set; }
        public string Answer { get; set; }

        public class UpdateQuestionCommandHandler: IRequestHandler<UpdateQuestionCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateQuestionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateQuestionCommand command, CancellationToken cancellationToken)
            {
                var question = _context.Questions.Where(a => a.Id == command.Id).FirstOrDefault();
                if(question == null)
                {
                    return default;
                }
                else
                {
                    question.Name = command.Name;
                    question.Values = command.Values;
                    question.Answer = command.Answer;
                    await _context.SaveChangesAsync();
                    return question.Id;
                }
            }
        }
    }
}
