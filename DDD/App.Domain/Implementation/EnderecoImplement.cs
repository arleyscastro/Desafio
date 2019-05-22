using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using App.Domain.Entity;
using App.Domain.Interface.Repository;
using App.Domain.Interface.Service;

namespace App.Domain.Implementation
{
    public class EnderecoImplement:IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoImplement(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public Endereco Add(Endereco entity)
        {
            return _enderecoRepository.Add(entity);
        }

        public void Update(Endereco entity)
        {
            _enderecoRepository.Update(entity);
        }

        public void Delete(Endereco entity)
        {
            _enderecoRepository.Delete(entity);
        }

        public IEnumerable<Endereco> GetAll()
        {
            return _enderecoRepository.GetAll();
        }

        public Endereco Get(int id)
        {
            return _enderecoRepository.Get(id);
        }

        public Endereco Get(Expression<Func<Endereco, bool>> condition)
        {
            return _enderecoRepository.Get(condition);
        }

        public Endereco GetByEmpresa(int idEmpresa)
        {
            return _enderecoRepository.GetByEmpresa(idEmpresa);
        }
    }
}
