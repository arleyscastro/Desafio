using System;
using System.Collections.Generic;
using App.Domain.Entity;
using System.Linq.Expressions;

namespace App.Domain.Interface.Service
{
    public interface IEnderecoService
    {
        Endereco Add(Endereco entity);
        void Update(Endereco entity);
        void Delete(Endereco entity);
        IEnumerable<Endereco> GetAll();
        Endereco Get(int id);
        Endereco Get(Expression<Func<Endereco, bool>> condition);
        Endereco GetByEmpresa(int idEmpresa);
    }
}