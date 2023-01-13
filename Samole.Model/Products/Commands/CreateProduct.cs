using MediatR;
using Samole.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace Samole.Model.Products.Commands;

public class CreateProduct : IRequest<AplicationServiceResponse<Product>>
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }
    public long Unit { get; set; }
}
