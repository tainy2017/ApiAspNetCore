using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApiAgendamentos.Persistence;
using ApiAgendamentos.Services;

namespace ApiAgendamentos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
           // services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("AgendamentoConection")));
            services.AddDbContext<bancoagendamentoContext>(options =>
             options.UseMySQL(
                 Configuration.GetConnectionString("AgendamentoConection")));
            services.AddScoped<IGerenciadorAgendamento, GerenciadorAgendamento>();
            services.AddScoped<IGerenciadorEmpresa, GerenciadorEmpresa>();
            services.AddScoped<IGerenciadorEstabelecimento, GerenciadorEstabelecimento>();
            services.AddScoped<IGerenciadorHorario, GerenciadorHorario>();
            services.AddScoped<IGerenciadorOcorrencia, GerenciadorOcorrencia>();
            services.AddScoped<IGerenciadorPessoa, GerenciadorPessoa>();
            services.AddScoped<IGerenciadorServico, GerenciadorServico>();
            //services.AddSingleton<IGerenciadorAgendamento, GerenciadorAgendamento>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
