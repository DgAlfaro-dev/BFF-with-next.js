using Microsoft.AspNetCore.Mvc;
using Products.Shared;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IEnumerable<Product> _products;
    public ProductsController(IEnumerable<Product> products) => _products = products;

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get() => Ok(_products);
}
