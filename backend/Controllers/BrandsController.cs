using BrandPromotion.API.Models;
using BrandPromotion.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrandPromotion.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Brand>>> GetAll() =>
        Ok(await _brandService.GetAllAsync());

    
}