using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Repository;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class QuestionRepositoryAsync : GenericRepositoryAsync<Question>, IQuestionRepository
    {
        public QuestionRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
