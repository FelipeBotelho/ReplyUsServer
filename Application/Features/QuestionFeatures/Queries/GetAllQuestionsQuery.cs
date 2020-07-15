using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuestionFeatures.Queries
{
    public class GetAllQuestionsQuery: IRequest<IEnumerable<Question>>
    {
        public class GetAllQuestionsQueryHandler: IRequestHandler<GetAllQuestionsQuery, IEnumerable<Question>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllQuestionsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Question>> Handle(GetAllQuestionsQuery query, CancellationToken cancellationToken)
            {
                var questionList = await _context.Questions.ToListAsync();
                if(questionList == null)
                {
                    return default;
                }
                return questionList.AsReadOnly();
            }
        }
    }
}
