using Samole.BLL.Framework;
using Samole.DAL.DbContexts;
using Samole.Model.Products;
using Samole.Model.Products.Commands;

namespace Samole.BLL.Products.Commands;

public class UpdateProductHandler : BaseApplicationServiceHandler<UpdateProduct, Product>
{
    public UpdateProductHandler(SampleDbContext dbContext) : base(dbContext)
    {
    }

    protected override async Task HandleRequest(UpdateProduct request, CancellationToken cancellationToken)
    {
        var product = _dbContext.Products.FirstOrDefault(c => c.Id == request.Id);

        if (product == null)
        {
            AddError($"Product {request.Id} yaft nashod.");
        }
        else
        {
            product.Name = request.Name;
            product.Unit = request.Unit;
            await _dbContext.SaveChangesAsync();
            AddResult(product);
        }
    }
}
