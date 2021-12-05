using Core.Entities;

namespace Entities.Concrete
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
