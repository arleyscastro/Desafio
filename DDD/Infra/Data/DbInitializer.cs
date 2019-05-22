using System.Linq;
using App.Domain.Entity;

namespace Infra.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Empresas.Any())
            {
                return;
            }

            context.Add(new Empresa
            {
                Nome = "Empesa inicializada automaticamente",
                CNPJ = "1234567890",
                Porte = App.Domain.Enumerator.PorteDaEmpresa.Grande
            });

            context.SaveChanges();
        }
    }
}
