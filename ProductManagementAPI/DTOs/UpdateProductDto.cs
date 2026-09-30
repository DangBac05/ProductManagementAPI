namespace ProductManagementAPI.DTOs;

public class UpdateProductDto
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string? Description { get; set; }
}