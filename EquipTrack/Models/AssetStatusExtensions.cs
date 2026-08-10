namespace EquipTrack.Models;

public static class AssetStatusExtensions
{
    public static string ToBadgeClass(this AssetStatus status) => status switch
    {
        AssetStatus.Active => "bg-success",
        AssetStatus.Decommissioned => "bg-secondary",
        AssetStatus.Recycled => "bg-dark",
        _ => "bg-light"
    };
}