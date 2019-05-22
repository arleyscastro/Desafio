using App.Domain.Entity;
using App.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using App.Domain.Interface.Repository;

namespace App.Domain.Implementation
{
    public class EmpresaImplement : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaImplement(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public Empresa Add(Empresa entity)
        {
            return _empresaRepository.Add(entity);
        }

        public void Update(Empresa entity)
        {
            _empresaRepository.Update(entity);
        }

        public void Delete(Empresa entity)
        {
            _empresaRepository.Delete(entity);
        }

        public IEnumerable<Empresa> GetAll()
        {
            return _empresaRepository.GetAll();
        }

        public IEnumerable<Empresa> GetAll(Expression<Func<Empresa, bool>> condition)
        {
            return _empresaRepository.GetAll(condition);
        }

        public Empresa Get(int id)
        {
            return _empresaRepository.Get(id);
        }

        public Empresa GetUsingSQLCommand(int Id)
        {
            return _empresaRepository.GetUsingSQLCommand(Id);
        }

        public Empresa Get(Expression<Func<Empresa, bool>> condition)
        {
            return _empresaRepository.Get(condition);
        }

        public Empresa Get(string cnpj)
        {
            return _empresaRepository.Get(cnpj);
        }

        public bool Any(Expression<Func<Empresa, bool>> condition)
        {
            return _empresaRepository.Any(condition);
        }
    }
}
