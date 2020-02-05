#load "..\command-builder.cake"

public class PowershellCommandRunner
{
    protected ICakeContext context;
    protected bool globalExceptionOnError;

    public PowershellCommandRunner(ICakeContext context, bool globalExceptionOnError = true)
    {
        this.context = context;
        this.globalExceptionOnError = globalExceptionOnError;
    }
    
    public T Run<T>(
        string command,
        CommandBuilder commandBuilder,
        Nullable<bool> exceptionOnError = null,
        bool logOutput = true)
    {
	    var output = RunCommand(
            command,
            commandBuilder,
            exceptionOnError, 
            logOutput);

        return context.DeserializeJson<T>(output);
    }

    public void Run(
        string command,
        CommandBuilder commandBuilder = null,
        Nullable<bool> exceptionOnError = null,
        bool logOutput = true)
    {
        RunCommand(
            command,
            commandBuilder,
            exceptionOnError,
            logOutput);
    }

    public string RunCommand(
        string command,
        CommandBuilder builder = null,
        Nullable<bool> commandExceptionOnError = null,
        bool logOutput = true)
    {
        var exceptionOnError = commandExceptionOnError ?? this.globalExceptionOnError;

        if (!exceptionOnError) {
            this.context.Information("ExceptionOnScriptError - OFF");
        }

        var psSettings = new PowershellSettings
            {
                ExceptionOnScriptError = exceptionOnError,
                OutputToAppConsole = logOutput,
                LogOutput = logOutput
            };

        if (builder != null) 
        {
            psSettings = psSettings
                .WithArguments(args => {
                    args.Append("--%");
                    args.Append(builder.Build());
                });
        }

        var outputLines = this.context.StartPowershellScript(command, psSettings)
            .Where(p => p.BaseObject is String)
            .Select(p => p.BaseObject)
            .Cast<string>();

        return string.Join(Environment.NewLine, outputLines);        
    }
}