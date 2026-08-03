using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EquipTrack.Data;
using EquipTrack.Models;

namespace EquipTrack.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var vm = new DashboardViewModel
        {
            ActiveCount = await _context.Assets.CountAsync(a => a.Status == AssetStatus.Active),
            DecommissionedCount = await _context.Assets.CountAsync(a => a.Status == AssetStatus.Decommissioned),
            RecycledCount = await _context.Assets.CountAsync(a => a.Status == AssetStatus.Recycled),
            CategoryCounts = await _context.Assets
                .GroupBy(a => a.Category!.Name)
                .Select(g => new CategoryCount { CategoryName = g.Key, Count = g.Count() })
                .ToListAsync(),
            ExpiringWarranties = await _context.Assets
                .Include(a => a.Category)
                .Where(a => a.WarrantyExpirationDate >= DateTime.Today && a.WarrantyExpirationDate <= DateTime.Today.AddDays(30))
                .ToListAsync()
        };

        if (vm.ExpiringWarranties.Any())
        {
            TempData["FlashMessage"] = $"{vm.ExpiringWarranties.Count} asset(s) have warranties expiring within 30 days.";
            TempData["FlashType"] = "warning";
        }

        return View(vm);
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}