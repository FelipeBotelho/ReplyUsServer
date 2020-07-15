using Domain.Common;

namespace Domain.Entities
{
    public class Player: BaseEntity
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }
}
