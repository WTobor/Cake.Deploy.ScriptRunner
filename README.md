# Build and deployment

This is an extension for Cake framework. It allows running scripts e.x. `az-cli` using Cake.

## Cake

[Cake](https://cakebuild.net/) (C# Make) is a cross-platform build automation system. It is built on top of the Roslyn compiler which enables you to write your build scripts in C#. You can create tasks such as compiling code, copying files and folders, running unit tests, compressing files and building NuGet packages.

## Prerequisites

1. Make sure [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-windows?view=azure-cli-latest) is installed (version 2.0.81 or later).
2. Make sure npm is installed.
3. (Optional) Use VSCode extension [markdownlint](https://marketplace.visualstudio.com/items?itemName=DavidAnson.vscode-markdownlint) to markdown file linting and style checking.

## Running the script

### Default task (it should run `Az-Show-Version` task)

```powershell
./deploy.ps1
```

### Run `Az-Login` task

```powershell
./deploy.ps1 -Target Az-Login
```

### Run `Az-Login-With-Set-Subscription` task with subscription parameter

```powershell
./deploy.ps1 --env="dev" --subscription= '*****' -Target Az-Login-With-Set-Subscription
```

Parameters:

- `--env`: environment (ex. `default`, `dev`)
- `--subscription`: name or ID of subscription

## Structure

### `deploy.ps1`

Bootstrapper script - it will automatically download Cake and other tools from NuGet and run main `deploy.cake` script with parameters.

### `deploy.cake`

Main script with logic - set available command runners (ex. `az` (azure-cli) and `ps` (Powershell) in the `Setup()`).

### `command-runner/powershell-command-runner.cake`

Base class for all runners. It contains logic that starts powershell scripts with specified settings and arguments.

### `command-runner/command-runner.cake`

Class for basic command runner - is uses script command (`toolName`, ex. `az`) that should be available from the console.

### `command-runner/npm-command-runner.cake`

Class for command runners installed in a specified location ("./node_modules/.bin/*.cmd").

## `npm.cake`

File with task to install npm packages.

### `commands/commands-az.cake`

File with sample tasks using az-cli.

### `cake.config`

Configuration file with nuget and tools paths - should not be modified.

### `tools\packages.config`

Configuration file with list of packages (ex. Cake) that should be installed.

### `package.json`

Configuration file with list of external npm packages.

### `variables-default.cake`

Configuration file with release variables (template, default one) for base environment. [Documentation](https://github.com/ObjectivityLtd/Cake.Deploy.Variables/blob/master/README.md)

### `variables-dev.cake`

Configuration file with release variables for `dev` environment (override  variables from base environment). [Documentation](https://github.com/ObjectivityLtd/Cake.Deploy.Variables/blob/master/README.md)
