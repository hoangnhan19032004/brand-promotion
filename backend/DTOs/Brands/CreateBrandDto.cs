using System.ComponentModel.DataAnnotations;

namespace BrandPromotion.API.DTOs.Brand;

public class CreateBrandDto
{
    [Required(ErrorMessage = "Tên thương hiệu không được để trống")]
    [StringLength(100, ErrorMessage = "Tên không được vượt quá 100 ký tự")]
    public string Name { get; set; } = null!;

    public string? Logo { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [Url(ErrorMessage = "Website không hợp lệ")]
    public string? Website { get; set; }
}