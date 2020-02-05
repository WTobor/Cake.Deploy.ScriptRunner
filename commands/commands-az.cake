Task("Az-Show-Version")
    .Does(() => {
        az.Run(a => {
                a.Append("version");
            });
    });

Task("Login")
    .Does(() => {
        //exceptionOnError: false because of default warning "WARNING: You have logged in. Now let us find all the subscriptions to which you have access..."
        az.Run(a => {
                a.Append("login");
            }, exceptionOnError: false);
    });

Task("Set-Subscription")
    .Does(() => {
        az.Run(a => {
                a.Append("account");
                a.Append("set");
                a.AppendSwitchQuoted("--subscription", ReleaseVariable("subscription"));
            });
    });