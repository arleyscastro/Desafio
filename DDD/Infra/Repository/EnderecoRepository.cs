using App.Domain.Entity;
using App.Domain.Interface.Repository;
using Infra.Data;

namespace Infra.Repository
{
    public class EnderecoRepository: Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Endereco GetByEmpresa(int idempresa)
        {
            return Get(end => end.IdEmpresa == idempresa);
        }
    }
}
