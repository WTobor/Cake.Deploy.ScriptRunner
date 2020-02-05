#load "command-runner.cake"

public class NpmCommandRunner: CommandRunner
{
    public NpmCommandRunner(ICakeContext context, string commandName, bool globalExceptionOnError = false)
        : base(context, context.MakeAbsolute(new FilePath($"./node_modules/.bin/{commandName}.cmd")).FullPath, globalExceptionOnError)
    {
    }
}