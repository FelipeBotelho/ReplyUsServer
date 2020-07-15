using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuestionFeatures.Queries
{
    public class GetQuestionByIdQuery: IRequest<Question>
    {
        public int Id { get; set; }
        public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, Question>
        {
            private readonly IApplicationDbContext _context;
            public GetQuestionByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Question> Handle(GetQuestionByIdQuery query, CancellationToken cancellationToken)
            {
                var question = _context.Questions.Where(a => a.Id == query.Id).FirstOrDefault();
                if (question == null) return default;
                return question;
            }
        }
    }
}
