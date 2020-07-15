using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuestionFeatures.Commands
{
    public class DeleteQuestionByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteQuestionByIdCommandHandler : IRequestHandler<DeleteQuestionByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public DeleteQuestionByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteQuestionByIdCommand command, CancellationToken cancellationToken)
            {
                var question = await _context.Questions.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (question == null) return default;
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
                return question.Id;
            }
        }
    }
}
