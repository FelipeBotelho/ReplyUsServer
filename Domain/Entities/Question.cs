using Domain.Common;

namespace Domain.Entities
{
    public class Question: BaseEntity
    {
        public string Name { get; set; }
        public string Values { get; set; }
        public string Answer { get; set; }
    }
}
