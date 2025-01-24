var builder = DistributedApplication.CreateBuilder(args);

var content = builder
    .AddContainer("content", "clue/json-server")
    .WithHttpEndpoint(port: 5001, targetPort: 80)
    .WithBindMount("../../moviedata.json", "/data/db.json")
    .WithArgs("db.json");

var movies = builder
    .AddProject<Projects.SnackFlix_Movies>("movies")
    .WithEnvironment("CONTENT_ENDPOINT", content.GetEndpoint("http"));
var reviews = builder.AddProject<Projects
    .SnackFlix_Reviews>("reviews")
    .WithEnvironment("CONTENT_ENDPOINT", content.GetEndpoint("http"));
var snacks = builder.AddProject<Projects.SnackFlix_Snacks>("snacks");

var api = builder.AddProject<Projects.SnackFlix_Api>("api")
    .WithReference(movies)
    .WithReference(snacks)
    .WithReference(reviews);

builder.Build().Run();