using App.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace UI.AppWeb.Controllers.SistemAPI
{
    [Route("api/empresa")]
    [ApiController]
    public class EmpresaApiController: ControllerBase
    {
        private IEmpresaService _empresaService;

        public EmpresaApiController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet("{id}")]
        public IActionResult GetEmpresaByCNPJ([FromRoute] int id)
        {
            return Ok(_empresaService.GetUsingSQLCommand(id));
        }
    }
}
