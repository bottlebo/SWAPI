using SWAPI;

var builder = WebApplication.CreateBuilder(args);

//builder.AddDbContext();

builder.AddServices();
builder.AddMappers();
builder.Services.AddControllers();
var app = builder.Build();
//app.Seed();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}


app.MapControllers();
app.Run();

