using App.Domain.Interface.Service;
using System.Collections.Generic;
using System.Linq;
using App.Domain.Enumerator;
using App.Domain.Validators;

namespace App.Domain.Entity
{
    public class Empresa
    {
        private IEmpresaService _empresaService;
        private IValidatorService _validatorService;
        public Empresa()
        {
            Enderecos = Enumerable.Empty<Endereco>();
        }

        public Empresa(IValidatorService validatorService, IEmpresaService empresaService, int idempresa,
                        string nome, string cnpj, PorteDaEmpresa porte)
        {
            _empresaService = empresaService;
            IdEmpresa = idempresa;
            Nome = nome;
            CNPJ = cnpj;
            Porte = porte;

            _validatorService = validatorService;
            _empresaService = empresaService;
            ValidarCNPJ(cnpj);
        }

        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public PorteDaEmpresa Porte { get; set; }
        public IEnumerable<Endereco> Enderecos{ get; set; }

        private void ValidarCNPJ(string cnpj)
        {
            if (_validatorService == null)
                return;

            var regrasException = new RegrasException<Empresa>();

            if (!_validatorService.IsCNPJValid(cnpj))
                regrasException.AdicionarErroPara(x => x.CNPJ, "CNPJ inválido");

            if (regrasException.Erros.Any())
                throw regrasException;
            else
            {
                if (_empresaService == null)
                    return;

                if (IdEmpresa > 0)
                {
                    if (_empresaService.Any(emp => emp.CNPJ.Equals(cnpj) && emp.IdEmpresa != IdEmpresa))
                    {
                        regrasException.AdicionarErroPara(x => x.CNPJ, "Já existe uma empresa com este CNPJ");
                    }
                }
                else
                {
                    if (_empresaService.Any(emp => emp.CNPJ.Equals(cnpj)))
                    {
                        regrasException.AdicionarErroPara(x => x.CNPJ, "Já existe uma empresa com este CNPJ");
                    }
                }

                if (regrasException.Erros.Any())
                    throw regrasException;
            }
        }
    }
}
