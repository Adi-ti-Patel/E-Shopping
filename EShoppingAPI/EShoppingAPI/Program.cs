using EShoppingAPI;
using EShoppingAPI.Interface;
using EShoppingAPI.Model;
using EShoppingAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("eshopping"));
});
builder.Services.AddTransient<ApplicationDbContext, ApplicationDbContext>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();   
builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Product
app.MapGet("/product", (IProductRepository repo) => {
    return Results.Ok(repo.GetAllItems());
});

app.MapGet("/product/{id}", (IProductRepository repo, int id) => {
    return Results.Ok(repo.GetItemById(id));
});

app.MapPut("/product", (IProductRepository repo, Product item) => {
    return Results.Ok(repo.UpdateItem(item));
});

app.MapPost("/product", (IProductRepository repo, Product item) =>
{
    return Results.Ok(repo.CreateItem(item));
});

app.MapDelete("/product/{id}", (IProductRepository repo, int id) =>
{
    return Results.Ok(repo.DeleteItem(id));
});

//User
app.MapGet("/user", (IUserRepository repo) => {
    return Results.Ok(repo.GetAllItems());
});

app.MapGet("/user/{id}", (IUserRepository repo, int id) => {
    return Results.Ok(repo.GetItemById(id));
});

app.MapPut("/user", (IUserRepository repo, User item) =>
{
    return Results.Ok(repo.UpdateItem(item));
});

app.MapPost("/user", (IUserRepository repo, User item) =>
{
    return Results.Ok(repo.CreateItem(item));
});

app.MapDelete("/user/{id}", (IUserRepository repo, int id) =>
{
    return Results.Ok(repo.DeleteItem(id));
});

//Order
app.MapGet("/order", (IOrderRepository repo) => {
    return Results.Ok(repo.GetAllItems());
});

app.MapGet("/order/{id}", (IOrderRepository repo, int id) => {
    return Results.Ok(repo.GetItemById(id));
});

app.MapPut("/order", (IOrderRepository repo, Order item) =>
{
    return Results.Ok(repo.UpdateItem(item));
});

app.MapPost("/order", (IOrderRepository repo, Order item) =>
{
    return Results.Ok(repo.CreateItem(item));
});

app.MapDelete("/order/{id}", (IOrderRepository repo, int id) =>
{
    return Results.Ok(repo.DeleteItem(id));
});

//Inventory
app.MapGet("/inventory", (IInventoryRepository repo) => {
    return Results.Ok(repo.GetAllItems());
});

app.MapGet("/inventory/{id}", (IInventoryRepository repo, int id) => {
    return Results.Ok(repo.GetItemById(id));
});

app.MapPut("/inventory", (IInventoryRepository repo, Inventory item) =>
{
    return Results.Ok(repo.UpdateItem(item));
});

app.MapPost("/inventory", (IInventoryRepository repo, Inventory item) =>
{
    return Results.Ok(repo.CreateItem(item));
});

app.MapDelete("/inventory/{id}", (IInventoryRepository repo, int id) =>
{
    return Results.Ok(repo.DeleteItem(id));
});

app.Run();

