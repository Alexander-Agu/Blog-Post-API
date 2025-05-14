using Blog.App.API.Data;
using Blog.App.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("BlogApp");
builder.Services.AddSqlite<BlogAppContext>(connString);
var app = builder.Build();

app.MapUserEndpoints();
await app.MigrateAsync();



app.Run();
