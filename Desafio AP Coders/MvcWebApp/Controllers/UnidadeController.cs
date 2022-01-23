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
    public class UnidadeController : Controller
    {
        private readonly MvcWebAppContext _context;

        public UnidadeController(MvcWebAppContext context)
        {
            _context = context;
        }

        // GET: Unidade
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unidades.ToListAsync());
        }

        // GET: Unidade/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidades.FirstOrDefaultAsync(m => m.indentificacao == id);

            if (unidade == null)
            {
                return NotFound();
            }

            return View(unidade);
        }

        // GET: Unidade/Create
        public IActionResult Create()
        {
            CarregaProprietarioDropDownList();
            return View();
        }

        // POST: Unidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("indentificacao,proprietario,condominio,endereco")] Unidade unidade)
        {
            CarregaProprietarioDropDownList();
            if (UnidadeExists(unidade.indentificacao))
            {
                ModelState.AddModelError("","Á unidade já existe!");
            }
            if (ModelState.IsValid)
            {
                _context.Add(unidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidade);
        }

        // GET: Unidade/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            CarregaProprietarioDropDownList();
            if (id == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidades.FindAsync(id);
            if (unidade == null)
            {
                return NotFound();
            }
            return View(unidade);
        }

        // POST: Unidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("indentificacao,proprietario,condominio,endereco")] Unidade unidade)
        {
            CarregaProprietarioDropDownList();

            if (id != unidade.indentificacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadeExists(unidade.indentificacao))
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
            return View(unidade);
        }

        // GET: Unidade/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidades
                .FirstOrDefaultAsync(m => m.indentificacao == id);
            if (unidade == null)
            {
                return NotFound();
            }

            return View(unidade);
        }

        // POST: Unidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var unidade = await _context.Unidades.FindAsync(id);
            _context.Unidades.Remove(unidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadeExists(string id)
        {
            return _context.Unidades.Any(e => e.indentificacao == id);
        }
        public void CarregaProprietarioDropDownList()
        {
            ViewData["proprietario"] = new SelectList(_context.inquilinos, "nome", "nome");
        }
    }
}
