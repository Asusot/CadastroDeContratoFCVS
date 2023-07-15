using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroDeContratoFCVS.Data;
using CadastroDeContratoFCVS.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CadastroDeContratoFCVS.Controllers
{
    public class ContratosController : Controller
    {
        private readonly CadastroDeContratoFCVSContext _context;

        public ContratosController(CadastroDeContratoFCVSContext context)
        {
            _context = context;
        }

        // GET: Contratos
        public IActionResult Index(string search)
        {
            var contratos = _context.Contrato.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                contratos = contratos.Where(c => c.NomeCliente.Contains(search) || c.NumeroContrato.ToString().Contains(search));
            }

            return View(contratos.ToList());
        }



        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contratos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contrato contrato, IFormFile arquivoPdf)
        {
            if (ModelState.IsValid)
            {
                if (arquivoPdf != null && arquivoPdf.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await arquivoPdf.CopyToAsync(memoryStream);
                        contrato.ArquivoPdf = memoryStream.ToArray();
                    }
                }

                _context.Contrato.Add(contrato);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(contrato);
        }


        // GET: Contratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCliente,NumeroContrato,ValorContrato,DataAssinatura")] Contrato contrato)
        {
            if (id != contrato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.Id))
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
            return View(contrato);
        }

        // GET: Contratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contrato = await _context.Contrato.FindAsync(id);
            _context.Contrato.Remove(contrato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
            return _context.Contrato.Any(e => e.Id == id);
        }
    }
}
