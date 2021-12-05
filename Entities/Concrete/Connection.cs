using Core.Entities;

namespace Entities.Concrete
{
    public class Connection : IEntity
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
    }
}
