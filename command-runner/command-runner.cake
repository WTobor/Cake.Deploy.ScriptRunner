using Cake.Powershell;
using Cake.Json;
using Cake.Core.IO;
using System;

public class CommandRunner : PowershellCommandRunner 
{
    private string toolName;

    public CommandRunner(ICakeContext context, string toolName, bool globalExceptionOnError = true)
        : base(context, globalExceptionOnError)
    {
        this.toolName = toolName;
    }

    public T Run<T>(Action<ProcessArgumentBuilder> builder,
        Nullable<bool> exceptionOnError = null,
        bool logOutput = true) => 
            this.Run<T>(
                this.toolName,
                builder,
                exceptionOnError, 
                logOutput);

    public void Run(Action<ProcessArgumentBuilder> builder,
        Nullable<bool> exceptionOnError = null,
        bool logOutput = true) => 
            this.Run(
                this.toolName,
                builder,
                exceptionOnError, 
                logOutput);
}
