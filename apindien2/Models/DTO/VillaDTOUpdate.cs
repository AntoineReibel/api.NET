using System.ComponentModel.DataAnnotations;

namespace apindien2.Models.DTO;

public class VillaDTOUpdate
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Surface { get; set; }
    [Required]
    public int Occupancy { get; set; }
}