using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuestionFeatures.Commands
{
    public class CreateQuestionCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Values { get; set; }
        public string Answer { get; set; }
        public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateQuestionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateQuestionCommand command, CancellationToken cancellationToken)
            {
                var question = new Question();
                question.Name = command.Name;
                question.Values = command.Values;
                question.Answer = command.Answer;
                _context.Questions.Add(question);
                await _context.SaveChangesAsync();
                return question.Id;
            }
        }
    }
}