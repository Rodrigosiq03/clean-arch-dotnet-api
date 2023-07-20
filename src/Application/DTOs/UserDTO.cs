using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Enums;

namespace Application.DTOs;

public class UserDTO
{
    [Required]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Field RaDTO is not valid")]
    public string Ra { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Field NameDTO is not valid")]
    public string Name { get; set; }
    
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Field EmailDTO is not valid")]
    public string Email { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public State State { get; set; }
    
    
}

