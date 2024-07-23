
//container create
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseStaticFiles();  // css and js files in wwwroot 

app.UseRouting();    //this  middleware makes us routing capable @RenderBody() 

app.UseAuthorization();

app.MapRazorPages();   // create relationship between .cshtml   cshtml.cs

app.Run();
