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
        Action<ProcessArgumentBuilder> argumentBuilder,
        Nullable<bool> exceptionOnError = null,
        bool logOutput = true)
    {
	    var output = RunCommand(
            command,
            argumentBuilder,
            exceptionOnError, 
            logOutput);

        return context.DeserializeJson<T>(output);
    }

    public void Run(
        string command,
        Action<ProcessArgumentBuilder> argumentBuilder,
        Nullable<bool> exceptionOnError = null,
        bool logOutput = true)
    {
        RunCommand(
            command,
            argumentBuilder,
            exceptionOnError,
            logOutput);
    }

    public string RunCommand(
        string command,
        Action<ProcessArgumentBuilder> argumentBuilder,
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
            }.WithArguments(argumentBuilder);

        var outputLines = this.context.StartPowershellScript(command, psSettings)
            .Where(p => p.BaseObject is String)
            .Select(p => p.BaseObject)
            .Cast<string>();

        return string.Join(Environment.NewLine, outputLines);        
    }
}