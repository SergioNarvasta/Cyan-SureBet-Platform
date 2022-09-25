using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IS_SureBet.Data;
using IS_SureBet.Models;

namespace IS_SureBet.Controllers
{
    public class BetDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BetDataController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(){
              return _context.BetData != null ? 
                          View(await _context.BetData.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BetData'  is null.");
        }
        public async Task<IActionResult> BetList(){
            return _context.BetData != null ?
                        View(await _context.BetData.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.BetData'  is null.");
        }
      
        public async Task<IActionResult> Details(int? id){
            if (id == null || _context.BetData == null){
                return NotFound();
            }
            var betData = await _context.BetData
                .FirstOrDefaultAsync(m => m.IdBet == id);
            if (betData == null){
                return NotFound();
            }
            return View(betData);
        }
        public async Task<IActionResult> Detalles(int? id){
            if (id == null || _context.BetData == null){
                return NotFound();
            }

            var betData = await _context.BetData
                .FirstOrDefaultAsync(m => m.IdBet == id);
            if (betData == null)
            {
                return NotFound();
            }

            return View(betData);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBet,Deporte,Evento,Mercado,Competicion,Cuota,Beneficio,CasaApuesta,Fecha,Limite")] BetData betData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(betData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(betData);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BetData == null)
            {
                return NotFound();
            }
            var betData = await _context.BetData.FindAsync(id);
            if (betData == null)
            {
                return NotFound();
            }
            return View(betData);
        }

        // POST: BetData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBet,Deporte,Evento,Mercado,Competicion,Cuota,Beneficio,CasaApuesta,Fecha,Limite")] BetData betData)
        {
            if (id != betData.IdBet)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(betData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BetDataExists(betData.IdBet))
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
            return View(betData);
        }

        // GET: BetData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BetData == null)
            {
                return NotFound();
            }

            var betData = await _context.BetData
                .FirstOrDefaultAsync(m => m.IdBet == id);
            if (betData == null)
            {
                return NotFound();
            }

            return View(betData);
        }

        // POST: BetData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BetData == null){
                return Problem("Entity set 'ApplicationDbContext.BetData'  is null.");
            }
            var betData = await _context.BetData.FindAsync(id);
            if (betData != null){
                _context.BetData.Remove(betData);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool BetDataExists(int id)
        {
          return (_context.BetData?.Any(e => e.IdBet == id)).GetValueOrDefault();
        }
    }
}
