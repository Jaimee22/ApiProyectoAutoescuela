using ApiProyectoAutoescuela.Data;
using ApiProyectoAutoescuela.Helpers;
using ApiProyectoAutoescuela.Repositories;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.OpenApi.Models;
using NSwag;
using NSwag.Generation.Processors.Security;

var builder = WebApplication.CreateBuilder(args);


//HABILITAR LA SEGURIDAD
HelperActionServicesOAuth helper = new HelperActionServicesOAuth(builder.Configuration);
builder.Services.AddSingleton<HelperActionServicesOAuth>(helper);
builder.Services.AddAuthentication(helper.GetAuthenticateSchema()).AddJwtBearer(helper.GetJwtBearerOptions());


builder.Services.AddAzureClients(factory =>
{
    factory.AddSecretClient
    (builder.Configuration.GetSection("KeyVault"));
});
SecretClient secretClient =
builder.Services.BuildServiceProvider().GetService<SecretClient>();
KeyVaultSecret secret =
    await secretClient.GetSecretAsync("SqlAzure");
string connectionString = secret.Value;


// Add services to the container.ç
//string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryAutoescuela>();
builder.Services.AddDbContext<AutoescuelaContext>(options => options.UseSqlServer(connectionString));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();




//builder.Services.AddSwaggerGen(options =>
//{
//	options.SwaggerDoc("v1", new OpenApiInfo
//	{
//		Title = "Api Autoescuela",
//		Description = "Api de proyecto Autoescuela",
//		Version = "v1",
//		Contact = new OpenApiContact()
//		{
//			Name = "Jaime Rodriguez",
//			Email = "jaime@gmail.com"
//		}
//	});
//});
builder.Services.AddOpenApiDocument(document =>
{
	document.Title = "Api Proyecto Autoescuela";
	document.Description = "Api Securizada para Proyecto Autoescuela";
	document.AddSecurity("JWT", Enumerable.Empty<string>(),
		new NSwag.OpenApiSecurityScheme
		{
			Type = OpenApiSecuritySchemeType.ApiKey,
			Name = "Authorization",
			In = OpenApiSecurityApiKeyLocation.Header,
			Description = "Copia y pega el Token en el campo 'Value:' de la siguiente manera: Bearer {Token JWT}."
		});
	document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
});



var app = builder.Build();
//app.UseSwagger();
app.UseOpenApi();
app.UseSwaggerUI(options =>
{
	options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api Autoescuela");
	options.RoutePrefix = "";
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
