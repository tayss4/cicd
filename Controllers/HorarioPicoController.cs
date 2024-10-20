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
    public class HorarioPicoController : ControllerBase
    {
        private List<HorarioPico> horariosPico;
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public HorarioPicoController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var horariosPico = _databaseContext.HorariosPico.Include(c => c.Cruzamento).ToList();
            return View(horariosPico);
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
        public IActionResult Create(HorarioPicoCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var horarioPico = _mapper.Map<HorarioPico>(viewModel);
                _databaseContext.HorariosPico.Add(horarioPico);
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
        public IActionResult Edit(HorarioPico horarioPico)
        {
            _databaseContext.Update(horarioPico);
            _databaseContext.SaveChanges();
            TempData["mensagemSucesso"] = $"Os dados foram alterados com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int horarioPicoId)
        {
            var horarioPico = _databaseContext.HorariosPico.Find(horarioPicoId);
            if (horarioPico != null)
            {
                _databaseContext.HorariosPico.Remove(horarioPico);
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
