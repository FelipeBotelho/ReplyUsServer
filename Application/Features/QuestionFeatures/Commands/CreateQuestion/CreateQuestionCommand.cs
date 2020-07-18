using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Features.QuestionFeatures.Commands.CreateQuestion
{
    public partial class CreateQuestionCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Values { get; set; }
        public string Answer { get; set; }
    }
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Response<int>>
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IMapper _mapper;
        public CreateQuestionCommandHandler(IQuestionRepository questionRepo, IMapper mapper)
        {
            _questionRepo = questionRepo;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = _mapper.Map<Question>(request);
            await _questionRepo.AddAsync(question);
            return new Response<int>(question.Id);
        }
    }
}
