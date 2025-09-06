
using Microsoft.OpenApi.Models;
using Minimal_API.NewFolder.Classes;
using Minimal_API.NewFolder.Classes.Model;


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
            //   builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PIZZA API", Description = "Keep track of your Products", Version = "v1" });
            });
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

            app.MapGet("/pizzas/{id}", (int id) => pizzaServices.GetPizza(id));
            app.MapGet("/pizzas", () => pizzaServices.GetPizzas());
            app.MapPost("/pizzas", (Pizza pizza) => pizzaServices.CreatePizza(pizza));
            app.MapPut("/pizzas", (Pizza pizza) => pizzaServices.UpdatePizza(pizza));
            app.MapDelete("/pizzas/{id}", (int id) => pizzaServices.RemovePizza(id));

            app.Run();
        }
    }
}
