using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.QuestionFeatures.Queries.GetAllQuestions
{
    public class GetQuestionsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Values { get; set; }
        public string Answer { get; set; }
    }
}
