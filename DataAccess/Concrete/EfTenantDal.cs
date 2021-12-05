using Core.DataAccess.Concrete;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfTenantDal : EfEntityRepositoryBase<Tenant>
    {
        public EfTenantDal(TenantServiceContext context) : base(context)
        {

        }
    }
}
