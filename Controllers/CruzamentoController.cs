using AutoMapper;
using Fiap.Web.Trafego.Data.Contexts;
using Fiap.Web.Trafego.Models;
using Fiap.Web.Trafego.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Trafego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CruzamentoController : ControllerBase
    {
        private List<Cruzamento> cruzamentos;
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public CruzamentoController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;


        }
        public IActionResult Index()
        {
            var listaCruzamento = _databaseContext.Cruzamentos.ToList();
            return View(listaCruzamento);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CruzamentoCreateViewModel { };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(PrevisaoCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var cruzamento = _mapper.Map<Cruzamento>(viewModel);
                _databaseContext.Cruzamentos.Add(cruzamento);
                _databaseContext.SaveChanges();
                TempData["mensagemSucesso"] = $"Cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                
                return View(viewModel);
            }
            
        }

        [HttpPost]
        public IActionResult Edit(Cruzamento cruzamento)
        {
            _databaseContext.Update(cruzamento);
            _databaseContext.SaveChanges();
            TempData["mensagemSucesso"] = $"Os dados foram alterados com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int registroId)
        {
            var cruzamento = _databaseContext.Cruzamentos.Find(registroId);
            if (cruzamento != null)
            {
                _databaseContext.Cruzamentos.Remove(cruzamento);
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
