using Products.Shared;
using Products.GrpcApi;

var builder = WebApplication.CreateBuilder(args);

// 👇 REGISTRAR servicios ANTES de Build()
var products = new List<Product>
{
    new(1, "Laptop Gamer", 1200),
    new(2, "Teclado Mecánico", 80),
    new(3, "Monitor 27\"", 300)
};

builder.Services.AddSingleton<IEnumerable<Product>>(products);

builder.Services.AddGrpc();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

// Middlewares
app.MapGrpcService<ProductsServiceImpl>();
app.MapGet("/", () => "gRPC server – use a gRPC client.");

app.Run();
