using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.DTOs;
using ProductManagementAPI.Features.Products.Commands;
using ProductManagementAPI.Features.Products.Queries;

namespace ProductManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProducts()
    {
        var result = await _mediator.Send(new GetProductsQuery());

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(
        CreateProductDto dto)
    {
        var command = new CreateProductCommand
        {
            Name = dto.Name,
            Price = dto.Price,
            Quantity = dto.Quantity,
            Description = dto.Description
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDto>> UpdateProduct(
        int id,
        UpdateProductDto dto)
    {
        var command = new UpdateProductCommand
        {
            Id = id,
            Name = dto.Name,
            Price = dto.Price,
            Quantity = dto.Quantity,
            Description = dto.Description
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _mediator.Send(
            new DeleteProductCommand
            {
                Id = id
            });

        if (!result)
        {
            return NotFound(new
            {
                message = "Không tìm thấy sản phẩm."
            });
        }

        return NoContent();
    }

    [HttpGet("dapper")]
    public async Task<ActionResult<List<ProductDto>>> GetProductsDapper()
    {
        var result = await _mediator.Send(new GetProductsDapperQuery());

        return Ok(result);
    }
}