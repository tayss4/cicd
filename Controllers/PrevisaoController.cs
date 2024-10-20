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
    public class PrevisaoController : ControllerBase
    {
        private List<Previsao> previsoes;
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public PrevisaoController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var previsoes = _databaseContext.Previsoes.Include(c => c.Cruzamento).ToList();
            return View(previsoes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new PrevisaoCreateViewModel
            {
                Cruzamentos = new SelectList(_databaseContext.Cruzamentos.ToList()
                , "CruzamentoId")
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(PrevisaoCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var previsao = _mapper.Map<Previsao>(viewModel);
                _databaseContext.Previsoes.Add(previsao);
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
        public IActionResult Edit(Previsao previsao)
        {
            _databaseContext.Update(previsao);
            _databaseContext.SaveChanges();
            TempData["mensagemSucesso"] = $"Os dados foram alterados com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int previsaoId)
        {
            var previsao = _databaseContext.Previsoes.Find(previsaoId);
            if (previsao != null)
            {
                _databaseContext.Previsoes.Remove(previsao);
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
