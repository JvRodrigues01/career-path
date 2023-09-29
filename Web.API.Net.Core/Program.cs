using Api.Configs;
using Api.HangFire;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services
    .AddDatabaseContext(configuration)
    //.AddNHibernate(configuration)
    .AddInfrastructureAndServices()
    .AddHangfireSettings()
    .AddAuthenticationAndAuthorization()
    .AddPresentation();

var app = builder.Build();

app.UseHangfireServer();
app.UseHangfireDashboard();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder =>
{
    builder.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});

app.MapControllers();

//RecurringJob.AddOrUpdate<IHangFireJobs>(job => job.DisableAbsentUsers(), Cron.MinuteInterval(1));

app.Run();
