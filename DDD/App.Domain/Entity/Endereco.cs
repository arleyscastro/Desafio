using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entity
{
    public class Endereco
    {
        public Endereco()
        {
        }

        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }

    }
}
