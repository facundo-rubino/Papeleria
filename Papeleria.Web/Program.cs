﻿using DataAccess.EntityFramework.Repositorios;
using BussinessLogic.InterfacesRepositorio;
using AppLogic.InterfacesCU.Usuarios;
using AppLogic.InterfacesCU.Articulos;
using AppLogic.CasosDeUso.Usuarios;
using AppLogic.CasosDeUso.Articulos;

var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        //Repositorios
        builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulosEF>();
        builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosEF>();
        builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidosEF>();
        //Casos de uso
        builder.Services.AddScoped<IAgregarUsuario, AgregarUsuarioCU>();
        builder.Services.AddScoped<IFindByEmail, FindByEmailCU>();
        builder.Services.AddScoped<ILogin, LoginCU>();
        builder.Services.AddScoped<IAgregarArticulo, AgregarArticuloCU>();

/******************************* Add session service ********************************/

builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(300);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        // Add the use session to the app
        app.UseSession();

        app.UseRouting();



        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();


