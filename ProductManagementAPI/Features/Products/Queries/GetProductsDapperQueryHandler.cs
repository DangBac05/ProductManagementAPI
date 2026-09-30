using Dapper;
using MediatR;
using ProductManagementAPI.Data;
using ProductManagementAPI.DTOs;

namespace ProductManagementAPI.Features.Products.Queries;

public class GetProductsDapperQueryHandler
    : IRequestHandler<GetProductsDapperQuery, List<ProductDto>>
{
    private readonly DapperContext _context;

    public GetProductsDapperQueryHandler(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> Handle(
        GetProductsDapperQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _context.CreateConnection();

        const string sql = """
            SELECT
                ID AS Id,
                NAME AS Name,
                PRICE AS Price,
                QUANTITY AS Quantity,
                DESCRIPTION AS Description
            FROM PRODUCTS
            ORDER BY ID
            """;

        var result = await connection.QueryAsync<ProductDto>(sql);

        return result.ToList();
    }
}