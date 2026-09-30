using MediatR;
using ProductManagementAPI.DTOs;

namespace ProductManagementAPI.Features.Products.Queries;

public class GetProductsQuery : IRequest<List<ProductDto>>
{
}