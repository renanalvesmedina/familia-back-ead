using Familia.Ead.Application.Utils;
using Familia.Ead.Infrastructure.Bootstrap;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Family School Api",
        Version = "v1",
        Description = "School platform of family church!",
        Contact = new OpenApiContact
        {
            Name = "Lumini Tecnologia",
            Url = new Uri("https://luminitec.com.br"),
        },
        License = new OpenApiLicense
        {
            Name = "Igreja Família",
            Url = new Uri("https://www.igrejafamilia.net.br/")
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddLuminiPresenter();
builder.Services.ConfigureServices(builder.Configuration);

//DI
builder.Services.AddScoped<IValidators, Validators>();
builder.Services.AddScoped<IUploadFileFactory, UploadFileFactory>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "myAllowOrigins", 
        policy =>
        {
            policy.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

app.Configure();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Familia Ead Api v1"));

app.UseCors("myAllowOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
