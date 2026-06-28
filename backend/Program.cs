using BrandPromotion.API.Services;
using BrandPromotion.API.Services.Interfaces;
using BrandPromotion.API.Settings;

var builder = WebApplication.CreateBuilder(args);

// ── MongoDB Settings ──────────────────────────────────
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

// ── Services ──────────────────────────────────────────
builder.Services.AddSingleton<IBrandService, BrandService>();

// ── CORS ──────────────────────────────────────────────
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// ── Controllers + Swagger ─────────────────────────────
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Brand Promotion API", Version = "v1" });
});

var app = builder.Build();

// ── Middleware Pipeline ───────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReact");
app.UseAuthorization();
app.MapControllers();

app.Run();