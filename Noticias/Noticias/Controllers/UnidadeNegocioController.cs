using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Noticias.Data;
using Noticias.Models;

namespace Noticias
{
    public class UnidadeNegocioController : Controller
    {
        private readonly DBNoticias _context;

        public UnidadeNegocioController(DBNoticias context)
        {
            _context = context;    
        }

        // GET: UnidadeNegocio
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnidadeNegocio.ToListAsync());
        }

        // GET: UnidadeNegocio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadeNegocio = await _context.UnidadeNegocio
                .SingleOrDefaultAsync(m => m.Id == id);
            if (unidadeNegocio == null)
            {
                return NotFound();
            }

            return View(unidadeNegocio);
        }

        // GET: UnidadeNegocio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadeNegocio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Id,UsuarioCriacao,UsuarioAlteracao,DataCadastro,DataAlteracao")] UnidadeNegocio unidadeNegocio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadeNegocio);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(unidadeNegocio);
        }

        // GET: UnidadeNegocio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadeNegocio = await _context.UnidadeNegocio.SingleOrDefaultAsync(m => m.Id == id);
            if (unidadeNegocio == null)
            {
                return NotFound();
            }
            return View(unidadeNegocio);
        }

        // POST: UnidadeNegocio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Id,UsuarioCriacao,UsuarioAlteracao,DataCadastro,DataAlteracao")] UnidadeNegocio unidadeNegocio)
        {
            if (id != unidadeNegocio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadeNegocio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadeNegocioExists(unidadeNegocio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(unidadeNegocio);
        }

        // GET: UnidadeNegocio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadeNegocio = await _context.UnidadeNegocio
                .SingleOrDefaultAsync(m => m.Id == id);
            if (unidadeNegocio == null)
            {
                return NotFound();
            }

            return View(unidadeNegocio);
        }

        // POST: UnidadeNegocio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidadeNegocio = await _context.UnidadeNegocio.SingleOrDefaultAsync(m => m.Id == id);
            _context.UnidadeNegocio.Remove(unidadeNegocio);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UnidadeNegocioExists(int id)
        {
            return _context.UnidadeNegocio.Any(e => e.Id == id);
        }
    }
}
