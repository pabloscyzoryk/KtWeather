using System.ComponentModel.DataAnnotations;

namespace KtWeather.Frontend;

public class Location
{
    [Required]
    [StringLength(30), MinLength(3)]
    public required string Name { get; set; }
}
