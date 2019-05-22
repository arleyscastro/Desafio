using System;
using System.Linq;
using App.Domain.Entity;
using App.Domain.Enumerator;
using App.Domain.Interface.Service;
using App.Domain.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UI.AppWeb.Models;

namespace UI.AppWeb.Controllers
{
    public class EmpresaController : Controller
    {
        private IEmpresaService _empresaService;
        private IValidatorService _validatorService;
        private IEnderecoService _enderecoService;

        public EmpresaController(IEmpresaService empresaService, IEnderecoService enderecoService, IValidatorService validatorService)
        {
            _empresaService = empresaService;
            _validatorService = validatorService;
            _enderecoService = enderecoService;
        }

        // Método GET : Empresa
        public ActionResult Index()
        {
            return View(_empresaService.GetAll().Select(empresa => new EmpresaViewModel
            {
                Idempresa = empresa.IdEmpresa,
                Nome = empresa.Nome,
                CNPJ = empresa.CNPJ,
                Porte = empresa.Porte
            }));
        }

        // GET exemplo: Empresa/Details/1
        public ActionResult Details(int id)
        {
            var empresa = _empresaService.Get(id);
            return View(new EmpresaViewModel
            {
                CNPJ = empresa.CNPJ,
                Idempresa = empresa.IdEmpresa,
                Nome = empresa.Nome,
                Porte = empresa.Porte
            });
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            Empresa empresa = null;

            string cNPJ = collection.FirstOrDefault(a => a.Key.Equals("cnpj", System.StringComparison.CurrentCultureIgnoreCase)).Value;
            string nome = collection.FirstOrDefault(a => a.Key.Equals("nome", System.StringComparison.CurrentCultureIgnoreCase)).Value;
            PorteDaEmpresa porte = Enum.Parse<PorteDaEmpresa>(collection.FirstOrDefault(a => a.Key.Equals("porte", System.StringComparison.CurrentCultureIgnoreCase)).Value);

            try
            {
                empresa = new Empresa(_validatorService, _empresaService, 0, nome, cNPJ, porte);
            }
            catch (RegrasException ex)
            {
                ex.CopiarErrosPara(ModelState);
            }

            if (ModelState.IsValid)
            {
                _empresaService.Add(empresa);
                return RedirectToAction(nameof(Index));
            }

            // Observar que para chegar nesta ponto
            // será reexibida a mesma view para que seja possível
            // mostrar os erros do ModelState para o usuário
            return View(new EmpresaViewModel
            {
                CNPJ = cNPJ,
                Nome = nome,
                Porte = porte
            });
        }

        public ActionResult Edit(int id)
        {
            var empresa = _empresaService.Get(id);
            return View(new EmpresaViewModel
            {
                Idempresa = empresa.IdEmpresa,
                Nome = empresa.Nome,
                CNPJ = empresa.CNPJ,
                Porte = empresa.Porte
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Empresa empresa = null;

            string cnpj = collection.FirstOrDefault(a => a.Key.Equals("cnpj", System.StringComparison.CurrentCultureIgnoreCase)).Value;
            string nome = collection.FirstOrDefault(a => a.Key.Equals("nome", System.StringComparison.CurrentCultureIgnoreCase)).Value;
            PorteDaEmpresa porte = Enum.Parse<PorteDaEmpresa>(collection.FirstOrDefault(a => a.Key.Equals("porte", System.StringComparison.CurrentCultureIgnoreCase)).Value);

            try
            {
                empresa = new Empresa(_validatorService, _empresaService, id, nome, cnpj, porte);
            }
            catch (RegrasException ex)
            {
                ex.CopiarErrosPara(ModelState);
            }

            if (ModelState.IsValid)
            {
                _empresaService.Update(empresa);
                return RedirectToAction(nameof(Index));
            }

            // Observar que para chegar nesta ponto
            // será reexibida a mesma view para que seja possível
            // mostrar os erros do ModelState para o usuário
            return View(new EmpresaViewModel
            {
                Nome = nome,
                CNPJ = cnpj,
                Porte = porte
            });
        }

        public ActionResult Delete(int id)
        {
            var empresa = _empresaService.Get(id);
            return View(new EmpresaViewModel
            {
                Idempresa = empresa.IdEmpresa,
                Nome = empresa.Nome,
                CNPJ = empresa.CNPJ,
                Porte = empresa.Porte
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Endereco endereco = _enderecoService.Get(ende => ende.IdEmpresa == id);
                if (endereco != null)
                {
                    _enderecoService.Delete(endereco);
                }

                Empresa empresa = _empresaService.Get(id);
                _empresaService.Delete(empresa);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
