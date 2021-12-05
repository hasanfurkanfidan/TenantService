using Core.Entities;

namespace Entities.Concrete
{
    public class Tenant : IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
