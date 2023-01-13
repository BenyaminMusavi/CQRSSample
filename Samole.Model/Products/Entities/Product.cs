using Samole.Model.Framework;

namespace Samole.Model.Products;

public class Product:BaseEntity
{
    public string Name { get; set; }
    public long Unit { get; set; }
}
