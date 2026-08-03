namespace EquipTrack.Models;

public class DashboardViewModel
{
    public int ActiveCount { get; set; }
    public int DecommissionedCount { get; set; }
    public int RecycledCount { get; set; }
    public List<CategoryCount> CategoryCounts { get; set; } = new();
    public List<Asset> ExpiringWarranties { get; set; } = new();
}

public class CategoryCount
{
    public string CategoryName { get; set; } = string.Empty;
    public int Count { get; set; }
}