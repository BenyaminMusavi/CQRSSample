using MediatR;
using Samole.DAL.DbContexts;
using Samole.Model.Framework;

namespace Samole.BLL.Framework;

public abstract class BaseApplicationServiceHandler<TRequest, TResult> :
    IRequestHandler<TRequest, AplicationServiceResponse<TResult>>
    where TRequest : IRequest<AplicationServiceResponse<TResult>>
{
    protected readonly SampleDbContext _dbContext;
    private AplicationServiceResponse<TResult> _response = new() { };

    public BaseApplicationServiceHandler(SampleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AplicationServiceResponse<TResult>> Handle
        (TRequest request, CancellationToken cancellationToken)
    {
        await HandleRequest(request, cancellationToken);
        return _response;
    }

    protected abstract Task HandleRequest(TRequest request, CancellationToken cancellationToken);

    public void AddError(string error)
    {
        _response.AddError(error);
    }

    public void AddResult(TResult result)
        => _response.Result = (result);
}