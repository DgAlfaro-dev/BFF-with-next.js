using Products.Shared;

var builder = WebApplication.CreateBuilder(args);

// 👇 REGISTRAR servicios ANTES de Build()
var products = new List<Product>
{
    new(1, "Laptop Gamer", 1200),
    new(2, "Teclado Mecánico", 80),
    new(3, "Monitor 27\"", 300)
};

builder.Services.AddSingleton<IEnumerable<Product>>(products);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(); // demo only

var app = builder.Build();

// Middlewares
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.UseRouting();


app.MapControllers();
app.Run();
