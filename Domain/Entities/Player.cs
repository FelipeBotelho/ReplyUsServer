using Domain.Common;

namespace Domain.Entities
{
    public class Player: AuditableBaseEntity
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }
}
