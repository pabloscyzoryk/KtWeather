using System.ComponentModel.DataAnnotations;

namespace KtWeather.Frontend.Models;

public class WeekTemp
{
    public float Temperature { get; set; }

    [Required]
    [StringLength(12)]
    public required string DayName { get; set; }
}
