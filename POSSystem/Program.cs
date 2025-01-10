using Microsoft.IdentityModel.Tokens;
using System.Text;
using POSSystem;
using POSSystem.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using POS.Utilities;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add JWT Authentication Service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("88762cdc83a54fd15893d7fbe00d9dae6cbd2d4c51a1fb66cd831fe50bcd362ab197b560beed42fca4d1646fdfb3da1636f86f6eb4c1d62a836a5dde99db9140cde1a749bbe27ccc26830d3b9e3c8344869561458fa0082407479a30a1a89bc2f59a476bb7ac5855fcd30a7c9a29193394ac91855e74dab3d07e58894f60e6866dd0aaa7718f2eb12a86d0d4b0f82650a5a2b8117e2c4d445127c95ae7a20a6c84d0c8436f6bdd129123eeec2b1c4aa497af7915173a9e33500daf405320f6b5e6001b2f2a608c46eefc9cee22d211c432dc1a3ee5be391298a4da32cd8102c0864c92f5854cdd5d4d59c8ce55169c951d5d57b16e358b5484e3d4e5284321b6")),
            ValidIssuer = "Authenticator",
            ValidAudience = "Resource"
        };


    });
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddAPI();
builder.Services.AddTransient<TokenGenerator>();

builder.Services.AddSwaggerGen(options =>
{
    // Define the Bearer authentication scheme
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter JWT Bearer token in the format **Bearer {your token}**"
    });

    // Add the security requirement to all endpoints
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] { }
        }
    });
});

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
//        c.OAuthClientId("swagger-client-id"); 
//        c.OAuthAppName("Swagger UI");         
//    });
//}


var app = builder.Build();
app.UseAuthentication();

// Use Authorization Middleware (ensure routes are protected)
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.MapControllers();

app.Run();


// check with jwt json web token 


;
