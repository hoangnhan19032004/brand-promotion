using BrandPromotion.API.Features.Brands.Commands.CreateBrand;
using BrandPromotion.API.Features.Brands.Commands.DeleteBrand;
using BrandPromotion.API.Features.Brands.Commands.UpdateBrand;
using BrandPromotion.API.Features.Brands.Queries.GetAllBrands;
using BrandPromotion.API.Features.Brands.Queries.GetBrandById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrandPromotion.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BrandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllBrandsQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _mediator.Send(new GetBrandByIdQuery(id));
        return result is null
            ? NotFound(new { message = $"Không tìm thấy thương hiệu với id: {id}" })
            : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBrandCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateBrandCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        command.Id = id;

        try
        {
            var result = await _mediator.Send(command);
            return result is null
                ? NotFound(new { message = $"Không tìm thấy thương hiệu với id: {id}" })
                : Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var deleted = await _mediator.Send(new DeleteBrandCommand(id));
        return deleted
            ? NoContent()
            : NotFound(new { message = $"Không tìm thấy thương hiệu với id: {id}" });
    }
}
