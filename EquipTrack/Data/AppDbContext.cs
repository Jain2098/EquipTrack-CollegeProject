using Microsoft.EntityFrameworkCore;
using EquipTrack.Models;

namespace EquipTrack.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Asset> Assets { get; set; }
    
    public DbSet<RecyclingRecord> RecyclingRecords { get; set; }
    
}