using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using onlinedostava.Interfejsi;
using onlinedostava.Maper;
using onlinedostava.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlinedostava
{
	public class Startup
	{
		private readonly string _cors = "cors";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "onlinedostava", Version = "v1" });
			});

			services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
		   .AddJwtBearer(options =>
		   {
			   options.TokenValidationParameters = new TokenValidationParameters //Podesavamo parametre za validaciju pristiglih tokena
			   {
				   ValidateIssuer = true, //Validira izdavaoca tokena
				   ValidateAudience = false, //Kazemo da ne validira primaoce tokena
				   ValidateLifetime = true,//Validira trajanje tokena
				   ValidateIssuerSigningKey = true, //validira potpis token, ovo je jako vazno!
				   ValidIssuer = "http://localhost:44351", //odredjujemo koji server je validni izdavalac
				   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]))//navodimo privatni kljuc kojim su potpisani nasi tokeni
			   };
		   });

			services.AddCors(options =>
			{
				options.AddPolicy(name: _cors, builder => {
					builder.WithOrigins("https://localhost:4200")//Ovde navodimo koje sve aplikacije smeju kontaktirati nasu,u ovom slucaju nas Angular front
						   .AllowAnyHeader()
						   .AllowAnyMethod()
						   .AllowCredentials();
				});
			});

			services.AddScoped<IKorisnickiProfilServis, KorisnickiProfilServis>();
			//services.AddScoped<IProductService, ProductService>();
			//services.AddScoped<IOrderService, OrderService>();

			//services.AddDbContext<DataBaseUserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OnlineDostavaDataBase")));

			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new Maperr());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c => {
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "onlinedostava v1");
				c.RoutePrefix = string.Empty;
				});
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				
			}

			app.UseHttpsRedirection();
			app.UseCors(_cors);

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
