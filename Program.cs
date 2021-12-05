using SsrTodo.Domain;
using SsrTodo.Controllers;
using SsrTodo.Pages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTodoServices();
builder.Services.AddTodoApi();
builder.Services.AddTodoPages();

var app = builder.Build();

app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "OPTIONS")
        .WithExposedHeaders("Location");
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
