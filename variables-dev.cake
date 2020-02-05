// example of new variable file for other environment
ReleaseEnvironment("dev")
    .IsBasedOn("default")
    .AddVariable("env", "dev");