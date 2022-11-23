using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebProjectLena.Data;
using WebProjectLena.Repositories.Books;
using WebProjectLena.Repositories.Comments;
using WebProjectLena.Repositories.Genres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IGenreReposiroty, GenreReposiroty>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();

builder.Services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CustomConnection")));
builder.Services.AddDbContext<BooksCatalogueContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthenticationContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
    var ctx2 = scope.ServiceProvider.GetRequiredService<BooksCatalogueContext>();

    // makes sure the databse is deleted every time the app runs, usefull for tests
    // but real apps should not use this, and save all changes in db, even when exiting the app.
    //ctx.Database.EnsureDeleted();
    //ctx2.Database.EnsureDeleted();

    ctx.Database.EnsureCreated();
    ctx2.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
