using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

public class Event
{
    public int EventId { get; set; }

    [Required(ErrorMessage = "Event name is required.")]
    public string? EventName { get; set; }

    [Required(ErrorMessage = "Event date is required.")]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    [Range(typeof(DateTime), "2025-01-01", "2030-12-31", ErrorMessage = "Event date must be between 2025-01-01 and 2030-12-31.")]
    public string? EventDate { get; set; }

    [Required(ErrorMessage = "Event location is required.")]
    public string? EventLocation { get; set; }
}