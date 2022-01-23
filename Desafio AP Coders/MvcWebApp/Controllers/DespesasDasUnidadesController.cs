#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc_web_app;
using mvc_web_app.Models;

namespace mvc_web_app.Controllers
{
    public class DespesaDaUnidadeController : Controller
    {
        private readonly MvcWebAppContext _context;

        public DespesaDaUnidadeController(MvcWebAppContext context)
        {
            _context = context;
        }

        // GET: DespesaDaUnidade

        public async Task<IActionResult> Index(string unidade, DateTime vencimento)
        {
            CarregaStatusDePagamentosDropDownList();
            CarregaTiposDeDespesas();
            IQueryable<DateTime> vencimentosdeQuery = from m in _context.DespesasDasUnidades orderby m.vencimento_fatura select m.vencimento_fatura;

            var despesaDaUnidade = from m in _context.DespesasDasUnidades select m;

            if (vencimento != default)
            {
                despesaDaUnidade = despesaDaUnidade.Where(s => s.vencimento_fatura == vencimento);
            }
            if (!string.IsNullOrEmpty(unidade))
            {
                despesaDaUnidade = despesaDaUnidade.Where(s => s.unidadeId.Contains(unidade));
            }

            var despesaDaUnidadeVM = new DespesasDasUnidadesViewModel();

            despesaDaUnidadeVM.DespesasDasUnidades = await despesaDaUnidade.ToListAsync();
            despesaDaUnidadeVM.Vencimentos = new SelectList(await vencimentosdeQuery.Distinct().ToListAsync());
            CarregaStatusDePagamentosDropDownList();
            CarregaTiposDeDespesas();

            return View(despesaDaUnidadeVM);
        }

        // GET: DespesaDaUnidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesaDaUnidade = await _context.DespesasDasUnidades
                .FirstOrDefaultAsync(m => m.id == id);
            if (despesaDaUnidade == null)
            {
                return NotFound();
            }

            return View(despesaDaUnidade);
        }

        // GET: DespesaDaUnidade/Create
        public IActionResult Create()
        {
            CarregaUnidadesDropDownList();
            CarregaTiposDeDespesas();
            CarregaStatusDePagamentosDropDownList();
            return View();
        }

        // POST: DespesaDaUnidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,tipoDespesa,valor,vencimento_fatura,statusPagamento,unidadeId")] DespesaDaUnidade despesaDaUnidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despesaDaUnidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CarregaUnidadesDropDownList();
            CarregaStatusDePagamentosDropDownList();
            CarregaTiposDeDespesas();
            return View(despesaDaUnidade);
        }

        // GET: DespesaDaUnidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesaDaUnidade = await _context.DespesasDasUnidades.FindAsync(id);
            if (despesaDaUnidade == null)
            {
                return NotFound();
            }
            CarregaUnidadesDropDownList();
            CarregaStatusDePagamentosDropDownList();
            CarregaTiposDeDespesas();
            return View(despesaDaUnidade);
        }

        // POST: DespesaDaUnidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,tipoDespesa,valor,vencimento_fatura,statusPagamento,unidadeId")] DespesaDaUnidade despesaDaUnidade)
        {
            if (id != despesaDaUnidade.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despesaDaUnidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesaDaUnidadeExists(despesaDaUnidade.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            CarregaUnidadesDropDownList();
            CarregaStatusDePagamentosDropDownList();
            CarregaTiposDeDespesas();
            return View(despesaDaUnidade);
        }

        // GET: DespesaDaUnidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesaDaUnidade = await _context.DespesasDasUnidades
                .FirstOrDefaultAsync(m => m.id == id);
            if (despesaDaUnidade == null)
            {
                return NotFound();
            }

            return View(despesaDaUnidade);
        }

        // POST: DespesaDaUnidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despesaDaUnidade = await _context.DespesasDasUnidades.FindAsync(id);
            _context.DespesasDasUnidades.Remove(despesaDaUnidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespesaDaUnidadeExists(int id)
        {
            return _context.DespesasDasUnidades.Any(e => e.id == id);
        }
        public void CarregaStatusDePagamentosDropDownList()
        {
            ViewData["statusPagamento"] = new SelectList(Enum.GetValues(typeof(StatusDosPagamentos)));
        }
        public void CarregaTiposDeDespesas()
        {
            ViewData["tipoDespesa"] = new SelectList(Enum.GetValues(typeof(TiposDeDespesas)));
        }

        public void CarregaUnidadesDropDownList()
        {
            ViewData["unidades"] = new SelectList(_context.Unidades, "indentificacao", "indentificacao");   
        }
    }
}
