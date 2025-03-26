using System.ComponentModel.DataAnnotations;

namespace AspApi2Server.DTOs;

public class ProductUpdateDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [Range(0.01, float.MaxValue)]
    public float Price { get; set; }
    
    [Required]
    public string Category { get; set; }
}