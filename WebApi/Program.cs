using AppLogic.CasosDeUso.Articulos;
using AppLogic.CasosDeUso.Pedidos;
using AppLogic.CasosDeUso.TiposMovimiento;
using AppLogic.CasosDeUso.Usuarios;
using AppLogic.InterfacesCU.Articulos;
using AppLogic.InterfacesCU.Pedidos;
using AppLogic.InterfacesCU.TiposMovimiento;
using AppLogic.InterfacesCU.Usuarios;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.InterfacesRepositorio;
using DataAccess.EntityFramework.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Repositorios
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosEF>();
builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidosEF>();
builder.Services.AddScoped<IRepositorioClientes, RepositorioClientesEF>();
builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulosEF>();
builder.Services.AddScoped<IRepositorioTiposMovimiento, RepositorioTiposMovimientoEF>();


//Casos de uso
builder.Services.AddScoped<IAgregarUsuario, AgregarUsuarioCU>();
builder.Services.AddScoped<IFindByEmail, FindByEmailCU>();
builder.Services.AddScoped<IUpdateUser, UpdateUserCU>();
builder.Services.AddScoped<ILogin, LoginCU>();
builder.Services.AddScoped<IAgregarArticulo, AgregarArticuloCU>();
builder.Services.AddScoped<IAgregarPedido, AgregarPedidoCU>();
builder.Services.AddScoped<IFindById, FindByIdCU>();
builder.Services.AddScoped<IObtenerArticulosAscendente, ObtenerArticulosAscendenteCU>();
builder.Services.AddScoped<IGetPedidosConCliente, GetPedidosConClienteCU>();
builder.Services.AddScoped<IObtenerTipos, ObtenerTiposMovimientoCU>();
builder.Services.AddScoped<IObtenerTipoPorId, ObtenerTipoPorIdCU>();
builder.Services.AddScoped<IAgregarTipo, AgregarTipoMovimientoCU>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
