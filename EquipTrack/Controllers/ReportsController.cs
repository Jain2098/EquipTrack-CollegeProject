using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EquipTrack.Data;

namespace EquipTrack.Controllers;

public class ReportsController : Controller
{
    private readonly AppDbContext _context;

    public ReportsController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    // Assets that have never been recycled
    public async Task<IActionResult> NeverRecycled()
    {
        var assets = await _context.Assets
            .Include(a => a.Category)
            .Where(a => !a.RecyclingRecords.Any())
            .ToListAsync();

        return View(assets);
    }

    // Total purchase value per category, highest first
    public async Task<IActionResult> ValueByCategory()
    {
        var results = await _context.Assets
            .GroupBy(a => a.Category!.Name)
            .Select(g => new CategoryValue
            {
                CategoryName = g.Key,
                TotalValue = g.Sum(a => a.PurchasePrice)
            })
            .OrderByDescending(x => x.TotalValue)
            .ToListAsync();

        return View(results);
    }

    // Conditional search by name and optional max price
    public async Task<IActionResult> Search(string? name, decimal? maxPrice)
    {
        var query = _context.Assets.Include(a => a.Category).AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(a => a.Name.Contains(name));
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(a => a.PurchasePrice <= maxPrice.Value);
        }

        var results = await query.ToListAsync();
        return View(results);
    }
}

public class CategoryValue
{
    public string CategoryName { get; set; } = string.Empty;
    public decimal TotalValue { get; set; }
}