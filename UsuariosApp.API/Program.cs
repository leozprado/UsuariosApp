using UsuariosApp.Domain.Interfaces.Repository;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Services;
using UsuariosApp.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Configuração para a documentação do Swagger
builder.Services.AddEndpointsApiExplorer(); //Swagger
builder.Services.AddSwaggerGen(); //Swagger

//Configurações de injeção de dependência
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IPerfilRepository, PerfilRepository>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Executando os serviços do Swagger (documentação da API)
app.UseSwagger(); //Swagger
app.UseSwaggerUI(); //Swagger

app.UseAuthorization();
app.MapControllers();
app.Run();


//declarando a classe program.cs como publica   
public partial class Program { }