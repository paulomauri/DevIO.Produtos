//using DevIO.Produtos.Application.Command;
//using DevIO.Produtos.Domain.Repository;
//using DevIO.Produtos.Infrastructure.Data;
//using DevIO.Produtos.Infrastructure.Repository;
//using Microsoft.EntityFrameworkCore;
//using Serilog;

//Log.Logger = new LoggerConfiguration()
//    .Enrich.FromLogContext()
//    .WriteTo.Elasticsearch(new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri("http://elasticsearch:9200"))
//    {
//        AutoRegisterTemplate = true,
//        IndexFormat = "produto-api-logs-{0:yyyy.MM.dd}"
//    })
//    .CreateLogger();

//var builder = WebApplication.CreateBuilder(args);
//builder.Host.UseSerilog();

//// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseInMemoryDatabase("ProdutosDb"));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProdutoCommand).Assembly));
//builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseSwagger();
//app.UseSwaggerUI();

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

// =============================== 

using DevIO.Produtos.Application.Command;
using DevIO.Produtos.Domain.Repository;
using DevIO.Produtos.Infrastructure.Data;
using DevIO.Produtos.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.Elasticsearch;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://elasticsearch:9200"))
    {
        AutoRegisterTemplate = true,
        IndexFormat = "produto-api-logs-" + DateTime.UtcNow.ToString("yyyy.MM.dd")
    })
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Faz o app escutar na porta 80 para funcionar corretamente no Docker
builder.WebHost.UseUrls("http://0.0.0.0:80");

// Usa Serilog
builder.Host.UseSerilog();

// Serviços
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ProdutosDb"));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProdutoCommand).Assembly));
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger sempre ativado
app.UseSwagger();
app.UseSwaggerUI();

// HTTPS redirection só fora do Docker
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

