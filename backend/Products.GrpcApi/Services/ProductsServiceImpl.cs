using Grpc.Core;
using Products.GrpcApi;
using Products.Shared; 

public class ProductsServiceImpl : ProductsService.ProductsServiceBase
{
    private readonly IEnumerable<Product> _products;

    public ProductsServiceImpl(IEnumerable<Product> products)
    {
        _products = products;
    }

    public override Task<ProductList> GetProducts(Empty request, ServerCallContext context)
    {
        var list = new ProductList();
        list.Items.AddRange(_products.Select(p =>
            new ProductMsg { Id = p.Id, Name = p.Name, Price = (double)p.Price }));
        return Task.FromResult(list);
    }
}
