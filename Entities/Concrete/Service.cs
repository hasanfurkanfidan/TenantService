using Core.Entities;

namespace Entities.Concrete
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
