var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.CleanArchitecture_Aspire_ApiService>("apiservice");

builder.AddProject<Projects.CleanArchitecture_Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.AddProject<Projects.service_test>("service-test");

builder.Build().Run();
