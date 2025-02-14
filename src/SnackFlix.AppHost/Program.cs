const string contentEndpoint = "CONTENT_ENDPOINT";

var builder = DistributedApplication.CreateBuilder(args);

var content = builder
    .AddContainer("content", "clue/json-server")
    .WithHttpEndpoint(port: 5001, targetPort: 80)
    .WithBindMount("../../moviedata.json", "/data/db.json")
    .WithArgs("db.json");

var accounts = builder
    .AddProject<Projects.SnackFlix_Accounts>("accounts")
    .WithEnvironment(contentEndpoint, content.GetEndpoint("http"));

var movies = builder
    .AddProject<Projects.SnackFlix_Movies>("movies")
    .WithEnvironment(contentEndpoint, content.GetEndpoint("http"));
var reviews = builder.AddProject<Projects
    .SnackFlix_Reviews>("reviews")
    .WithEnvironment(contentEndpoint, content.GetEndpoint("http"));
var snacks = builder.AddProject<Projects.SnackFlix_Snacks>("snacks");

var api = builder.AddProject<Projects.SnackFlix_Api>("api")
    .WithReference(accounts)
    .WithReference(movies)
    .WithReference(snacks)
    .WithReference(reviews);

builder.AddProject<Projects.SnackFlix_Razor>("razor")
    .WithReference(api)
    .WaitFor(api);

builder.AddNpmApp("vue", "../SnackFlix.Vue")
    .WithReference(api)
    .WaitFor(api)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();

