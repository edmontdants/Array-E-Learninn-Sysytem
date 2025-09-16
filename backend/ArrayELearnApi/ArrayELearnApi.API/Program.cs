using ArrayELearnApi.API.Filters;
using ArrayELearnApi.API.Middlewares;
using ArrayELearnApi.Application.Extensions;
using ArrayELearnApi.Application.Services;
using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Infrastructure.Extensions;
using ArrayELearnApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// This line configures Kestrel
//builder.WebHost.UseKestrel();

//Log.Logger = new LoggerConfiguration()
//    .Enrich.FromLogContext()
//    .Enrich.WithEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
//    .Enrich.WithEnvironmentName()
//    .Enrich.WithEnvironmentUserName()
//    .Enrich.WithMachineName()
//    .Enrich.WithProcessId()
//    .Enrich.WithThreadId()
//    .WriteTo.Console(
//        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties}{NewLine}{Exception}"
//    )
//    .WriteTo.File(
//        //new Serilog.Formatting.Json.JsonFormatter(),
//        //path: "Logs/log-.json",
//        path: "Logs/ArrayElearn-.log",          // Relative to the root folder
//        rollingInterval: RollingInterval.Day,  // Create new file each day
//        retainedFileCountLimit: 30,     // Keep last 30 files (optional)
//        rollOnFileSizeLimit: true,      // Split file if over limit
//        fileSizeLimitBytes: 10_000_000, // 10 MB per file (optional)
//        shared: true,
//        flushToDiskInterval: TimeSpan.FromSeconds(1),
//        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj} | UserId={UserId} CorrelationId={CorrelationId} {Properties}{NewLine}{Exception}"
//    )
//    .CreateLogger();

//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .CreateLogger();
//builder.Host.UseSerilog();

builder.Host.UseSerilog((ctx, loggerConfig) => { loggerConfig.ReadFrom.Configuration(ctx.Configuration); });

//builder.Logging.ClearProviders().AddSerilog();

#region Register Services & Background jobs to the Container.

//builder.Services.AddLogging(loggingBuilder =>
//{
//    loggingBuilder.ClearProviders();
//    loggingBuilder.AddSerilog(dispose: true);
//});

//builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

//builder.Services.AddExceptionHandler(options => options.ExceptionHandlingPath = "/error");

//builder.Services.AddProblemDetails();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                    //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    options.UseLazyLoadingProxies();
                });

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddApplication()
                .AddInfrastructure(builder.Configuration);

builder.Services.AddSignalR();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateRolesFilter>();
});

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

//builder.Services.AddHostedService<TokenCleanupService>();
builder.Services.Configure<HostOptions>(options =>
{
    options.ServicesStartConcurrently = true;
    // Set the shutdown timeout to 30 seconds
    //options.ShutdownTimeout = TimeSpan.FromSeconds(30);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors Polices
builder.Services.AddCors(options =>
{
    options.AddPolicy("RestrictedCors", policy =>
    {
        // Read the allowed origins from config
        var allowedOrigins = builder.Configuration
            .GetSection("Cors:AllowedOrigins")
            .Get<string[]>();

        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
        //policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

#endregion Register Services & Background jobs to the Container.

var app = builder.Build();

#region Configure the HTTP request pipeline.

// Seed roles & admin
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    await SeedData.InitializeAsync(services);
//}

// Middleware & endpoints
//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseMiddleware<LoggingContextMiddleware>();

//app.UseExceptionHandler();
//app.UseExceptionHandler("/error");
//app.Map("/error", (HttpContext httpContext) =>
//{
//    var feature = httpContext.Features.Get<IExceptionHandlerFeature>();
//    var ex = feature?.Error;

//    return Results.Problem(
//        title: "An unexpected error occurred.",
//        detail: ex?.Message,
//        statusCode: StatusCodes.Status400BadRequest
//    );
//});

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");

    //app.UseDeveloperExceptionPage();
    
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Array ELearning API SWagger EndPoint v1.0"));
}
else if (app.Environment.IsProduction())
{
    app.UseHsts();
    
    app.UseCors("RestrictedCors");
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

//app.MapHub<NotificationHub>("/notificationHub");

//app.MapHub<ChatHub>("/chatHub");

app.MapControllers();

#endregion

app.Run();
