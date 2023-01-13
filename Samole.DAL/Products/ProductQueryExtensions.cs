using Microsoft.EntityFrameworkCore;
using Samole.Model.Products;
using Samole.Model.Products.Dtos;

namespace Samole.DAL.Products;

public static class ProductQueryExtensions
{
    public static IQueryable<Product> WhereOver(this IQueryable<Product> products, string productName)
    {
        if (!string.IsNullOrEmpty(productName))
            products = products.Where(t => t.Name.Contains(productName));
        return products;
    }

    public static List<ProductQueryResult> ToProductQr(this IQueryable<Product> products)
    {
        return products.Select(c => new ProductQueryResult
        {
            Id = c.Id,
            Name = c.Name,
            Unit = c.Unit,
        }).ToList();
    }

    public static async Task<List<ProductQueryResult>> ToProductQrAsync(this IQueryable<Product> products)
    {
        return await products.Select(c => new ProductQueryResult
        {
            Id = c.Id,
            Name = c.Name,
            Unit = c.Unit,
        }).ToListAsync();
    }
}