using App.Domain.Enumerator;
using System.ComponentModel.DataAnnotations;

namespace UI.AppWeb.Models
{
    public class EmpresaViewModel
    {
        public int Idempresa { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        [MinLength(3, ErrorMessage = "Nome precisa pelo menos 3 caracteres")]
        [MaxLength(255, ErrorMessage = "Nome pode ter no máximo 255 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CNPJ é obrigatório")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "Porte da empresa é obrigatório")]
        public PorteDaEmpresa Porte { get; set; }
    }
}
