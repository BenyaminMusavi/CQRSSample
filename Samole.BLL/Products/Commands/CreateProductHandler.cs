using Samole.BLL.Framework;
using Samole.DAL.DbContexts;
using Samole.Model.Products;
using Samole.Model.Products.Commands;

namespace Samole.BLL.Products.Commands;

public class CreateProductHandler : BaseApplicationServiceHandler<CreateProduct , Product>
{
    public CreateProductHandler(SampleDbContext dbContext) : base(dbContext)
    {
    }

    protected override async Task HandleRequest(CreateProduct request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Unit = request.Unit,
        };
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        AddResult(product);
    }
}