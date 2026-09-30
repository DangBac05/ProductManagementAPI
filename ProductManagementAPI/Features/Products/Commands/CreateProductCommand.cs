using MediatR;
using ProductManagementAPI.DTOs;

namespace ProductManagementAPI.Features.Products.Commands;

public class CreateProductCommand : IRequest<ProductDto>
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string? Description { get; set; }
}