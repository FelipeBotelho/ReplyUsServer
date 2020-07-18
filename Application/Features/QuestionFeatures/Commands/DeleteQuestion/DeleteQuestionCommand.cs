using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuestionFeatures.Commands.DeleteQuestion
{
    public partial class DeleteQuestionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, Response<int>>
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IMapper _mapper;
        public DeleteQuestionCommandHandler(IQuestionRepository questionRepo, IMapper mapper)
        {
            _questionRepo = questionRepo;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _questionRepo.GetByIdAsync(request.Id);
            if (question == null) return default;
            await _questionRepo.DeleteAsync(question);
            return new Response<int>(question.Id);
        }
    }
}
