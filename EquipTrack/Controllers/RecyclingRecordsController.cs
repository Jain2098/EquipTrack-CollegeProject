using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EquipTrack.Data;
using EquipTrack.Models;

namespace EquipTrack.Controllers
{
    public class RecyclingRecordsController : Controller
    {
        private readonly AppDbContext _context;

        public RecyclingRecordsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RecyclingRecords
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.RecyclingRecords.Include(r => r.Asset);
            return View(await appDbContext.ToListAsync());
        }

        // GET: RecyclingRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclingRecord = await _context.RecyclingRecords
                .Include(r => r.Asset)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recyclingRecord == null)
            {
                return NotFound();
            }

            return View(recyclingRecord);
        }

        // GET: RecyclingRecords/Create
        public IActionResult Create()
        {
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Name");
            return View();
        }

        // POST: RecyclingRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetId,DisposedOn,WipeMethod,DisposalMethod,Notes")] RecyclingRecord recyclingRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recyclingRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Name", recyclingRecord.AssetId);
            return View(recyclingRecord);
        }

        // GET: RecyclingRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclingRecord = await _context.RecyclingRecords.FindAsync(id);
            if (recyclingRecord == null)
            {
                return NotFound();
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Name", recyclingRecord.AssetId);
            return View(recyclingRecord);
        }

        // POST: RecyclingRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssetId,DisposedOn,WipeMethod,DisposalMethod,Notes")] RecyclingRecord recyclingRecord)
        {
            if (id != recyclingRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recyclingRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecyclingRecordExists(recyclingRecord.Id))
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
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Name", recyclingRecord.AssetId);
            return View(recyclingRecord);
        }

        // GET: RecyclingRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclingRecord = await _context.RecyclingRecords
                .Include(r => r.Asset)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recyclingRecord == null)
            {
                return NotFound();
            }

            return View(recyclingRecord);
        }

        // POST: RecyclingRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recyclingRecord = await _context.RecyclingRecords.FindAsync(id);
            if (recyclingRecord != null)
            {
                _context.RecyclingRecords.Remove(recyclingRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecyclingRecordExists(int id)
        {
            return _context.RecyclingRecords.Any(e => e.Id == id);
        }
    }
}
