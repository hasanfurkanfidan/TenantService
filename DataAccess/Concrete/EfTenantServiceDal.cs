using Core.DataAccess.Concrete;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfTenantServiceDal : EfEntityRepositoryBase<TenantService>
    {
        public EfTenantServiceDal(TenantServiceContext context) : base(context)
        {

        }
    }
}
