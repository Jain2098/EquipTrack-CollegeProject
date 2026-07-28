using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipTrack.Models;

public class Asset : IValidatableObject
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string SerialNumber { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Model { get; set; }

    [StringLength(50)]
    public string? Manufacturer { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime PurchaseDate { get; set; }

    [Range(0, 100000)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal PurchasePrice { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime WarrantyExpirationDate { get; set; }

    [Required]
    public AssetStatus Status { get; set; } = AssetStatus.Active;

    public string? CustomFieldsJson { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
    
    public ICollection<RecyclingRecord> RecyclingRecords { get; set; } = new List<RecyclingRecord>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (WarrantyExpirationDate < PurchaseDate)
        {
            yield return new ValidationResult(
                "Warranty expiration date can't be before the purchase date.",
                new[] { nameof(WarrantyExpirationDate) });
        }
    }
}