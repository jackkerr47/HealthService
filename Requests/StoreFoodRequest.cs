using System.ComponentModel.DataAnnotations;

namespace HealthService.Requests;

public class StoreFoodRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public int? Calories { get; set; }
    
    [Required]
    public DateTime? TimeEaten { get; set; }
}