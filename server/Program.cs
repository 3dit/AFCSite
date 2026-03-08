using AFCSite.Server.Data;
using AFCSite.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------------------------------
// Services
// ---------------------------------------------------------------------------
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("AFCContext")
        ?? throw new InvalidOperationException("Connection string 'AFCContext' not found.")));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.Cookie.HttpOnly = true;
    opts.Cookie.SameSite = SameSiteMode.Strict;
    opts.Events.OnRedirectToLogin = ctx =>
    {
        ctx.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    opts.Events.OnRedirectToAccessDenied = ctx =>
    {
        ctx.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
});

var app = builder.Build();

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// ---------------------------------------------------------------------------
// Middleware pipeline
// ---------------------------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();

// API routes
app.MapControllers();

// Serve the Angular prerendered output from wwwroot.
// During development, point at the Angular dist folder directly so you
// don't need to rebuild .NET after every 'ng build'.
var angularRoot = app.Environment.IsDevelopment()
    ? Path.Combine(app.Environment.ContentRootPath, "..", "dist", "AFCSite", "browser")
    : Path.Combine(app.Environment.ContentRootPath, "wwwroot");

if (Directory.Exists(angularRoot))
{
    var fileProvider = new PhysicalFileProvider(Path.GetFullPath(angularRoot));

    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = fileProvider,
        RequestPath = "",
        ServeUnknownFileTypes = false,
        OnPrepareResponse = ctx =>
        {
            // Cache hashed assets for 1 year; HTML for 0 (so fresh prerendered pages always load)
            var path = ctx.File.Name;
            if (path.EndsWith(".js") || path.EndsWith(".css") || path.EndsWith(".woff2"))
            {
                ctx.Context.Response.Headers.CacheControl = "public, max-age=31536000, immutable";
            }
            else if (path.EndsWith(".html"))
            {
                ctx.Context.Response.Headers.CacheControl = "no-cache";
            }
        }
    });

    // SPA fallback — serves index.html for any route not matched by API or static files.
    // Angular prerendered pages are already in folders (e.g. /recipes/index.html), so
    // UseDefaultFiles + directory browsing picks those up. For truly unknown routes
    // (client-side-only), fall back to the root index.html.
    app.MapFallback(async context =>
    {
        // Try serving a prerendered index.html for the requested path first
        var requestPath = context.Request.Path.Value?.TrimStart('/') ?? "";
        var prerenderPath = Path.Combine(angularRoot, requestPath, "index.html");

        if (File.Exists(prerenderPath))
        {
            context.Response.ContentType = "text/html";
            context.Response.Headers.CacheControl = "no-cache";
            await context.Response.SendFileAsync(prerenderPath);
            return;
        }

        // Fallback to root index.html or index.csr.html (Angular will handle routing client-side)
        var fallbackPath = Path.Combine(angularRoot, "index.html");
        if (!File.Exists(fallbackPath))
            fallbackPath = Path.Combine(angularRoot, "index.csr.html");
        if (File.Exists(fallbackPath))
        {
            context.Response.ContentType = "text/html";
            context.Response.Headers.CacheControl = "no-cache";
            await context.Response.SendFileAsync(fallbackPath);
        }
        else
        {
            context.Response.StatusCode = 404;
        }
    });
}

app.Run();
