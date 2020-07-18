using Application.Interfaces.Repositories;
using FluentValidation;

namespace Application.Features.QuestionFeatures.Commands.CreateQuestion
{
    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        private readonly IQuestionRepository _questionRepo;

        public CreateQuestionCommandValidator(IQuestionRepository questionRepository)
        {
            this._questionRepo = questionRepository;

            RuleFor(p => p.Values)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            //.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
            //.MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Answer)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
                //.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }
        //public async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        //{
        //    // TODO Check performance here
        //    var products = await productRepository.GetAllAsync();
        //    if (products.Count == 0) return true;
        //    var unique = products.Where(a => a.Barcode == barcode).ToList();
        //    if (unique.Count > 0) return false;
        //    return true;
        //}
    }
}
