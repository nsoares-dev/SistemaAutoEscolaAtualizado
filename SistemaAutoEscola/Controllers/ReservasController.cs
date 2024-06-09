using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaAutoEscola.Data;
using SistemaAutoEscola.Models;

namespace SistemaAutoEscola.Controllers
{
    public class ReservasController : Controller
    {
        private readonly SistemaAutoEscolaContext _context;

        public ReservasController(SistemaAutoEscolaContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var sistemaAutoEscolaContext = _context.Reserva.Include(r => r.Carro).Include(r => r.Cliente);
            return View(await sistemaAutoEscolaContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Carro)
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["CarroId"] = new SelectList(_context.Carro, "CarroId", "NomeCarro");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente");
            ViewBag.CarrosDisponiveis = CarrosDisponiveis();
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaId,DataReserva,CarroId,ClienteId")] Reserva reserva)
        {
            var cliente = _context.Cliente.Find(reserva.ClienteId);
            if (cliente == null || !cliente.AprovadoDetran)
            {
                ModelState.AddModelError("", "Você não pode reservar um carro porque não está aprovado pelo Detran.");
                return View(reserva);
            }


            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();

                var carro = await _context.Carro.FindAsync(reserva.CarroId);
                if (carro != null)
                {
                    carro.JaReservado = true;
                    carro.ReservaId = reserva.ReservaId;
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                reserva.DataReserva = DateTime.Now;
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroId"] = new SelectList(_context.Carro, "CarroId", "NomeCarro", reserva.CarroId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", reserva.ClienteId);
            ViewBag.CarrosDisponiveis = CarrosDisponiveis();
            return View(reserva);
        }
        private List<SelectListItem> CarrosDisponiveis()
        {
            var carrosDisponiveis = _context.Carro
                .Where(c => !c.JaReservado).Select(c => new SelectListItem
                {
                    Value = c.CarroId.ToString(),
                    Text = c.NomeCarro
                }).ToList();

            return carrosDisponiveis;
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["CarroId"] = new SelectList(_context.Carro, "CarroId", "NomeCarro", reserva.CarroId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", reserva.ClienteId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaId,DataReserva,CarroId,ClienteId")] Reserva reserva)
        {
            if (id != reserva.ReservaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ReservaId))
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
            ViewData["CarroId"] = new SelectList(_context.Carro, "CarroId", "CarroId", reserva.CarroId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", reserva.ClienteId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Carro)
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.ReservaId == id);
        }
    }
}
