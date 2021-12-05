using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company>, ICompanyDal
    {
        public EfCompanyDal(TenantServiceContext tenantServiceContext) : base(tenantServiceContext)
        {

        }
    }
}
