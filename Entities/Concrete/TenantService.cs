using Core.Entities;

namespace Entities.Concrete
{
    public class TenantService : IEntity
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int ServiceId { get; set; }
        public int ConnectionId { get; set; }
        public Tenant Tenant { get; set; }
        public Service Service { get; set; }
        public Connection Connection { get; set; }
    }
}
