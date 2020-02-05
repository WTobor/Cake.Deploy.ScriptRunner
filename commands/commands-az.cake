Task("Az-Show-Version")
    .Does(() => {
        az.Run(new CommandBuilder(string.Empty).With("version", string.Empty));
    });

Task("Login")
    .Does(() => {
        az.Run(new CommandBuilder("login"), exceptionOnError: false);
    });

Task("Set-Subscription")
    .Does(() => {
        var builder = new CommandBuilder("account set")
                        .With("subscription", ReleaseVariable("subscription"));

        az.Run(builder);
    });