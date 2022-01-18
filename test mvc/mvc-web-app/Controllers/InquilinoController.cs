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
    public class InquilinoController : Controller
    {
        private readonly MvcWebAppContext _context;

        public InquilinoController(MvcWebAppContext context)
        {
            _context = context;
        }

        // GET: Inquilino
        public async Task<IActionResult> Index()
        {
            return View(await _context.inquilino.ToListAsync());
        }

        // GET: Inquilino/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilino = await _context.inquilino
                .FirstOrDefaultAsync(m => m.nome == id);
            if (inquilino == null)
            {
                return NotFound();
            }

            return View(inquilino);
        }

        // GET: Inquilino/Create
        public IActionResult Create()
        {
            ViewData["sexo"] = new SelectList(Enum.GetValues(typeof(Sexo)));
            return View();
        }

        // POST: Inquilino/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nome,idade,sexo,telefone,email")] Inquilino inquilino)
        {   if(InquilinoExists(inquilino.nome))
            {
                ModelState.AddModelError("","O inquilino já existe!");
            }
            if (ModelState.IsValid)
            {
                _context.Add(inquilino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["sexo"] = new SelectList(Enum.GetValues(typeof(Sexo)));
            return View(inquilino);
        }

        // GET: Inquilino/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilino = await _context.inquilino.FindAsync(id);
            if (inquilino == null)
            {
                return NotFound();
            }
            return View(inquilino);
        }

        // POST: Inquilino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("nome,idade,sexo,telefone,email")] Inquilino inquilino)
        {
            if (id != inquilino.nome)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inquilino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InquilinoExists(inquilino.nome))
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
            return View(inquilino);
        }

        // GET: Inquilino/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilino = await _context.inquilino
                .FirstOrDefaultAsync(m => m.nome == id);
            if (inquilino == null)
            {
                return NotFound();
            }

            return View(inquilino);
        }

        // POST: Inquilino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var inquilino = await _context.inquilino.FindAsync(id);
            _context.inquilino.Remove(inquilino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InquilinoExists(string id)
        {
            return _context.inquilino.Any(e => e.nome == id);
        }
    }
}
