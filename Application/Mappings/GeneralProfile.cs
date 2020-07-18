using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.QuestionFeatures.Commands.CreateQuestion;
using Application.Features.QuestionFeatures.Queries;
using Application.Features.QuestionFeatures.Queries.GetAllQuestions;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //Product
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            //Questions
            CreateMap<Question, GetQuestionsViewModel>().ReverseMap();
            CreateMap<CreateQuestionCommand, Question>();
            CreateMap<GetAllQuestionsQuery, GetAllQuestionsParameter>();
        }
    }
}
