#addin "nuget:https://api.nuget.org/v3/index.json?package=Cake.Powershell&version=0.4.8"
#addin "nuget:https://api.nuget.org/v3/index.json?package=Cake.Json&version=4.0.0"
#addin "nuget:https://api.nuget.org/v3/index.json?package=Cake.Deploy.Variables&version=0.3.0"
#addin "nuget:https://api.nuget.org/v3/index.json?package=Cake.Npm&version=0.17.0"

#load "command-runner/command-runner.cake"
#load "command-runner/powershell-command-runner.cake"
#load "commands/commands-az.cake"
#load "npm.cake"
#load "variables-default.cake"
#load "variables-dev.cake"

CommandRunner az;
PowershellCommandRunner ps;

Setup(context =>
{
    az = new CommandRunner(context, "az");
    ps = new PowershellCommandRunner(context);;
});

Task("Default-Az-Show-Version")
    .IsDependentOn("Install-NpmPackages")
    .IsDependentOn("Az-Show-Version");

Task("Az-Login")
    .IsDependentOn("Login");

Task("Az-Login-With-Set-Subscription")
    .IsDependentOn("Az-Login")
    .IsDependentOn("Set-Subscription");

var targetName = Argument("target", "Default-Az-Show-Version");

RunTarget(targetName);