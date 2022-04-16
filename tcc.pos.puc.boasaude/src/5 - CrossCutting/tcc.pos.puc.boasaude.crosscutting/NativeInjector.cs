using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using tcc.pos.puc.boasaude.application.Service;
using tcc.pos.puc.boasaude.domain.Interface;
using tcc.pos.puc.boasaude.repository.Config;
using tcc.pos.puc.boasaude.repository.Repository;

namespace tcc.pos.puc.boasaude.crosscutting
{
    public static class NativeInjector
    {
        public static void RegistrarDependecias(this IServiceCollection services)
        {
            services.AddScoped<IPlanoService, PlanoService>();
            services.AddScoped<IBoaSaudeRepository, BoaSaudeRepository>();
            services.AddScoped<IAssociadoService, AssociadoService>();

            //var json = Environment.GetEnvironmentVariable("CONFIGURACAODATABASE");

            //try
            //{
            //    var config = JsonConvert.DeserializeObject<ConfiguracaoDataBase>(json);
            //    services.AddSingleton(config);
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception);
            //    throw;
            //}
        }
    }
}