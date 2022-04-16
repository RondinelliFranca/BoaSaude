using Microsoft.OpenApi.Models;

namespace tcc.pos.puc.boasaude.api.Swagger;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "TCC Api Boa Saúde.",
                Version = "1.0.0", 
                Description = "Trabalho de conclusão de pós graduação da PUC Minas",
                Contact = new OpenApiContact
                {
                    Name = "Rondinelli França & Marcus Vinicius",
                    Email = "tcc.puc@boasaude.com"
                },
            });

            var xmlFile = $"{typeof(ServiceCollectionExtensions).Assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

        });
        return services;
    }
}