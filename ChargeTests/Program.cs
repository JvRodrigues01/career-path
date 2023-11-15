using NBomber.CSharp;

using var httpClient = new HttpClient();

var scenario = Scenario.Create("First Charge Test", async context =>
{
    var response = await httpClient.GetAsync("https://localhost:7180/api/Product");
    
    return response.IsSuccessStatusCode
        ? Response.Ok()
        : Response.Fail();
})
.WithoutWarmUp()
.WithLoadSimulations(
    Simulation.Inject(rate: 10,
        interval: TimeSpan.FromSeconds(1),
        during: TimeSpan.FromSeconds(30))
);

NBomberRunner.RegisterScenarios(scenario)
    .Run();