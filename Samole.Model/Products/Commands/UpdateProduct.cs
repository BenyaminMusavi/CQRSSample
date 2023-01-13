using MediatR;
using Samole.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace Samole.Model.Products.Commands;

public class UpdateProduct : IRequest<AplicationServiceResponse<Product>>
{
    [Required]
    [Range(1, long.MaxValue)]
    public long Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }
    public long Unit { get; set; }
}