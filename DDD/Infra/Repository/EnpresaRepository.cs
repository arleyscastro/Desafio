using App.Domain.Entity;
using App.Domain.Interface.Repository;
using Infra.Data;

namespace Infra.Repository
{
    public class EnpresaRepository: Repository<Empresa>, IEmpresaRepository
    {
        public EnpresaRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Empresa Get(string cnpj)
        {
            return Get(emp => emp.CNPJ.Equals(cnpj));
        }
    }
}
