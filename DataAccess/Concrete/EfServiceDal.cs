using Core.DataAccess.Concrete;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfServiceDal : EfEntityRepositoryBase<Service>
    {
        public EfServiceDal(TenantServiceContext context) : base(context)
        {

        }
    }
}
