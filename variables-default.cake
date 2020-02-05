// example of basic variable file
ReleaseEnvironment("default")
    .AddVariable("subscription", x => Argument<string>("subscription"));