
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Minimal_API.NewFolder.Classes;
using Minimal_API.NewFolder.Classes.Model;
using Minimal_API.NewFolder.Context;
using Minimal_API.NewFolder.Interfaces;


namespace Minimal_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

           // builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<PizzaContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            //   builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PIZZA API", Description = "Keep track of your Products", Version = "v1" });
            });
            builder.Services.AddScoped<IPizzaRepository,PizzaRepository>();
            builder.Services.AddScoped<IPizzaServicesEF,PizzaServicesEF>();
            PizzaServices pizzaServices = new PizzaServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ATOS API V1");
                });


            }
            app.UseHttpsRedirection();

            /*app.MapGet("/pizzas/{id}", (int id) => pizzaServices.GetPizza(id));
            app.MapGet("/pizzas", () => pizzaServices.GetPizzas());
            app.MapPost("/pizzas", (Pizza pizza) => pizzaServices.CreatePizza(pizza));
            app.MapPut("/pizzas", (Pizza pizza) => pizzaServices.UpdatePizza(pizza));
            app.MapDelete("/pizzas/{id}", (int id) => pizzaServices.RemovePizza(id));*/

            app.MapGet("/pizzas/{id}", async (int id, IPizzaServicesEF servicesEF) =>
            {
                try
                {
                    var pizza = await servicesEF.GetPizzaByIdAsync(id);
                    return Results.Ok(pizza);

                }
                catch(Exception e)
                {
                    return Results.NotFound();
                }


            });
            app.MapGet("/pizzas", async (IPizzaServicesEF servicesEF) =>
            {
                var pizzas = await servicesEF.GetAllPizzaAsync();
                return Results.Ok(pizzas);
            });
            app.MapPost("/pizzas", async (Pizza pizza, IPizzaServicesEF servicesEF) =>
            {
                await servicesEF.AddAsync(pizza);
                return Results.Created($"/pizzas/", pizza);
            });
            app.MapPut("/pizzas", async (Pizza pizza, IPizzaServicesEF servicesEF) =>
            {
                try
                {
                    await servicesEF.Update(pizza);
                    return Results.NoContent();
                }
                catch (Exception e)
                {
                    return Results.NotFound();
                }
              
            });
            app.MapDelete("/pizzas/{id}", async (int id, IPizzaServicesEF servicesEF) =>
            {   try
                {
                    await servicesEF.Delete(id);
                    return Results.NoContent();
                }
               
                 catch(Exception e)
                {
                return Results.NotFound();
            }

        });


            app.Run();
        }
    }
}
