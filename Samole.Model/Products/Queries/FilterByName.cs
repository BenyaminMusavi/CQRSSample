using MediatR;
using Samole.Model.Framework;
using Samole.Model.Products.Dtos;

namespace Samole.Model.Products.Queries;

public class FilterByName:IRequest<AplicationServiceResponse<List<ProductQueryResult>>>
{
    public string? Name { get; set; }
}
