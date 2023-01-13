using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Samole.Api.Framework;

[Route("[controller]")]
[ApiController]
public abstract class BaseController<T> : Controller where T : class
{
    protected readonly IMediator _mediator;
    protected readonly ILogger<T> _logger;
    protected readonly ILogger _logger2;

    public BaseController(IMediator mediator, ILogger<T> logger, ILoggerFactory loggerFactory)
    {
        _mediator = mediator;
        _logger = logger;
        _logger2 = loggerFactory.CreateLogger("ProductComponents");
    }
}
