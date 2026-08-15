using System.ComponentModel.DataAnnotations;

namespace EquipTrack.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Asset> Assets { get; set; } = new List<Asset>();
}