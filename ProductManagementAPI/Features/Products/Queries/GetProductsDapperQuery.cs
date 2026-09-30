using MediatR;
using ProductManagementAPI.DTOs;

namespace ProductManagementAPI.Features.Products.Queries;

public class GetProductsDapperQuery : IRequest<List<ProductDto>>
{
}