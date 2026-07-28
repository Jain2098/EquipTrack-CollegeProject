using System.ComponentModel.DataAnnotations;

namespace EquipTrack.Models;

public class RecyclingRecord
{
    public int Id { get; set; }

    [Required]
    public int AssetId { get; set; }

    public Asset? Asset { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DisposedOn { get; set; }

    [Required]
    [StringLength(100)]
    public string WipeMethod { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string DisposalMethod { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Notes { get; set; }
}