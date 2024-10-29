using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkshoAPI", Version = "v1" });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
    app.UseSwagger(); // 
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkshoAPI v1")); 
}


app.UseAuthorization(); 

app.MapControllers(); 

app.Run(); 

