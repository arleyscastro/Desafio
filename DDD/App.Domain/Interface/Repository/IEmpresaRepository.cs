using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entity;

namespace App.Domain.Interface.Repository
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Empresa Get(string cnpj);
    }
}
