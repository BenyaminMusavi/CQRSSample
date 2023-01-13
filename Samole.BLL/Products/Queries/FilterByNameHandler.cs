using Samole.BLL.Framework;
using Samole.DAL.DbContexts;
using Samole.DAL.Products;
using Samole.Model.Products.Dtos;
using Samole.Model.Products.Queries;

namespace Samole.BLL.Products.Queries;

public class FilterByNameHandler : BaseApplicationServiceHandler<FilterByName, List<ProductQueryResult>>
{
    public FilterByNameHandler(SampleDbContext dbContext) : base(dbContext)
    {
    }

    protected override async Task HandleRequest(FilterByName request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Products.WhereOver(request.Name).ToProductQrAsync();
        AddResult(result);
    }
}