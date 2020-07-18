using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuestionFeatures.Queries.GetAllQuestions
{
    public class GetAllQuestionsQuery : IRequest<PagedResponse<IEnumerable<GetQuestionsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, PagedResponse<IEnumerable<GetQuestionsViewModel>>>
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IMapper _mapper;
        public GetAllQuestionsQueryHandler(IQuestionRepository questionRepo, IMapper mapper)
        {
            _questionRepo = questionRepo;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetQuestionsViewModel>>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllQuestionsParameter>(request);
            var question = await _questionRepo.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var questionViewModel = _mapper.Map<IEnumerable<GetQuestionsViewModel>>(question);
            return new PagedResponse<IEnumerable<GetQuestionsViewModel>>(questionViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
