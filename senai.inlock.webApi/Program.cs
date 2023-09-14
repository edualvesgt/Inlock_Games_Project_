using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace senai.inlock.webApi_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Adiciona o servico de Controller
            builder.Services.AddControllers();

            //Adiciona serviço de Jwt Bearer (forma de autenticação)
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = "JwtBearer";
                options.DefaultAuthenticateScheme = "JwtBearer";
            })

            .AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //valida quem está solicitando
                    ValidateIssuer = true,

                    //valida quem está recebendo
                    ValidateAudience = true,

                    //define se o tempo de expiração será validado
                    ValidateLifetime = true,

                    //forma de criptografia e valida a chave de autenticação
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-games-chave-autenticacao-webapi-dev")),

                    //valida o tempo de expiração do token
                    ClockSkew = TimeSpan.FromMinutes(5),

                    //nome do issuer (de onde está vindo)
                    ValidIssuer = "inlock_games",

                    //nome do audience (para onde está indo)
                    ValidAudience = "inlock_games"
                };
            });

            //Adiciona o servico Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                //Adiciona informacoes sobre a API no Swagger
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API inlock Manha",
                    Description = "API para gerenciamento de inlock",
                    Contact = new OpenApiContact
                    {
                        Name = "GitHub Do Desenvolvedor",
                        Url = new Uri("https://github.com/RichardRichk")
                    },
                });

                //Configure o Swagger para usar o arquivo XML gerado com as instruções anteriores.
                // using System.Reflection;
                //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                //Usando a autenticaçao no Swagger
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Value: Bearer TokenJWT ",
                });
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
                    new string[] {}
                }
                });

            });


            var app = builder.Build();


            //Comeca a configuracao do Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            //Finaliza a configuracao do Swagger


            //Adiciona mapeamento dos Controllers
            app.MapControllers();


            //Adiciona a Autenticacao
            app.UseAuthentication();

            //Adiciona autorização
            app.UseAuthorization();


            app.UseHttpsRedirection();

            app.Run();
        }
    }
}