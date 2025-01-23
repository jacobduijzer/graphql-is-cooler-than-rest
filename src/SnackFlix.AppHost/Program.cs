var builder = DistributedApplication.CreateBuilder(args);

var movies = builder.AddProject<Projects.SnackFlix_Movies>("movies");
var snacks = builder.AddProject<Projects.SnackFlix_Snacks>("snacks");
var reviews = builder.AddProject<Projects.SnackFlix_Reviews>("reviews");

var api = builder.AddProject<Projects.SnackFlix_Api>("api")
    .WithReference(movies)
    .WithReference(snacks)
    .WithReference(reviews);

builder.Build().Run();