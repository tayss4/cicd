using AutoMapper;
using Fiap.Web.Trafego.Data.Contexts;
using Fiap.Web.Trafego.Models;
using Fiap.Web.Trafego.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Trafego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private List<Registro> registros;
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        
        public RegistroController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var registros = _databaseContext.Registros.Include(c => c.Cruzamento).ToList();
            return View(registros);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new RegistroCreateViewModel
            {
                Cruzamentos =new SelectList(_databaseContext.Cruzamentos.ToList()
                , "CruzamentoId")
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(RegistroCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var registro = _mapper.Map<Registro>(viewModel);
                _databaseContext.Registros.Add(registro);
                _databaseContext.SaveChanges();
                TempData["mensagemSucesso"] = $"Cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                viewModel.Cruzamentos = new SelectList(_databaseContext.Cruzamentos.ToList()
                    , "CruzamentoId");
                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult Edit(Registro registro)
        {
            _databaseContext.Update(registro);
            _databaseContext.SaveChanges();
            TempData["mensagemSucesso"] = $"Os dados foram alterados com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int registroId)
        {
            var registro = _databaseContext.Registros.Find(registroId);
            if (registro != null)
            {
                _databaseContext.Registros.Remove(registro);
                _databaseContext.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados foram removidos com sucesso";
            }
            else
            {
                TempData["mensagemSucesso"] = "OPS !!! Dado inexistente.";
            }
            return RedirectToAction("Index");
        }
    }
}
