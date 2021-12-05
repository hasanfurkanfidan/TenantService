using Core.DataAccess.Concrete;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfConnectionDal : EfEntityRepositoryBase<Connection>
    {
        public EfConnectionDal(TenantServiceContext context) : base(context)
        {

        }
    }
}
