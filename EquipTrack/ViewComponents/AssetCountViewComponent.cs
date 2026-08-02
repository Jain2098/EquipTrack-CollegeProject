using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EquipTrack.Data;

namespace EquipTrack.ViewComponents;

public class AssetCountViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public AssetCountViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var count = await _context.Assets.CountAsync();
        return View(count);
    }
}