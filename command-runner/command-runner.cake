using Cake.Powershell;
using Cake.Json;

#load "..\command-builder.cake"

public class CommandRunner : PowershellCommandRunner 
{
    private string toolName;

    public CommandRunner(ICakeContext context, string toolName, bool globalExceptionOnError = true)
        : base(context, globalExceptionOnError)
    {
        this.toolName = toolName;
    }

    public T Run<T>(
        CommandBuilder commandBuilder,
        Nullable<bool> exceptionOnError = null,
        bool logOutput = true) => 
            this.Run<T>(
                this.toolName,
                commandBuilder,
                exceptionOnError, 
                logOutput);

    public void Run(
        CommandBuilder commandBuilder,
        Nullable<bool> exceptionOnError = null,
        bool logOutput = true)
    {
        this.Run(
            this.toolName,
            commandBuilder,
            exceptionOnError, 
            logOutput);
    }
}
