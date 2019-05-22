using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace App.Domain.Enumerator
{
    public enum PorteDaEmpresa
    {
        [Description("Pequena")]
        [Display(Name = "Pequena")]
        Pequena = 1,
        [Description("Média")]
        [Display(Name = "Média")]
        Media = 2,
        [Description("Grande")]
        [Display(Name = "Grande")]
        Grande = 3
    }
}
