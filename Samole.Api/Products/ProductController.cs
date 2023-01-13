using MediatR;
using Microsoft.AspNetCore.Mvc;
using Samole.Api.Framework;
using Samole.Model.Products.Commands;
using Samole.Model.Products.Queries;

namespace Samole.Api.Products;

public class ProductController : BaseController<ProductController>
{
    public ProductController(IMediator mediator, ILogger<ProductController> logger, ILoggerFactory loggerFactory)
        : base(mediator, logger, loggerFactory)
    {
    }

    [HttpPost("CreateProduct")]
    public async Task<IActionResult> CreateProduct(CreateProduct model)
    {
        var response = await _mediator.Send(model);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }

    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(UpdateProduct model)
    {
        _logger.LogInformation("Request for product with id:{ID} responsed", model.Id);
        _logger2.LogInformation("Request for product with id:{ID} responsed", model.Id);

        var response = await _mediator.Send(model);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }

    [HttpGet(Name = "SearchProduct")]
    public async Task<IActionResult> Get([FromQuery]FilterByName model)
    {
        var response = await _mediator.Send(model);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
}
