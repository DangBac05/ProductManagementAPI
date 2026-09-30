using MediatR;

namespace ProductManagementAPI.Features.Products.Commands;

public class DeleteProductCommand : IRequest<bool>
{
    public int Id { get; set; }
}