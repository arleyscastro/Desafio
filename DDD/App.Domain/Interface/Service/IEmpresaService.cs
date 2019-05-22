using App.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace App.Domain.Interface.Service
{
    public interface IEmpresaService
    {
        Empresa Add(Empresa entity);
        void Update(Empresa entity);
        void Delete(Empresa entity);
        IEnumerable<Empresa> GetAll();
        IEnumerable<Empresa> GetAll(Expression<Func<Empresa, bool>> condition);
        Empresa Get(int id);
        Empresa GetUsingSQLCommand(int Id);
        Empresa Get(Expression<Func<Empresa, bool>> condition);
        Empresa Get(string cnpj);
        bool Any(Expression<Func<Empresa, bool>> condition);
    }
}
