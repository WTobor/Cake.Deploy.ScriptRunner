# Build and deployment

This is an extension for Cake framework. It allows running scripts e.x. `az-cli` using Cake.

## Prerequisites

1. Make sure [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-windows?view=azure-cli-latest) is installed (version 2.0.81 or later).
2. Make sure npm is installed.
3. Use VSCode extension [markdownlint](https://marketplace.visualstudio.com/items?itemName=DavidAnson.vscode-markdownlint) to markdown file linting and style checking.

## How to add Cake.Deploy.ScriptRunner

In order to use it add the following line in your addin section:

```cake
#addin Cake.Deploy.ScriptRunner
```

## Running the script

### Default tasks

#### A) Run default task (it should run `Az-Show-Version` task)

```powershell
./deploy.ps1
```

#### B) Run `Az-Login` task

```powershell
./deploy.ps1 -Target Az-Login
```

#### C) Run `Az-Login-With-Set-Subscription` task subscription parameter

```powershell
./deploy.ps1 --env="dev" --subscription= '*****' -Target Az-Login-With-Set-Subscription
```

Parameters:

- `--env`: environment (ex. `default`, `dev`)
- `--subscription`: name or ID of subscription
