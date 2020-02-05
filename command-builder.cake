public class CommandBuilder
{
	private string command;
	private string argumentPrefix;
	private List<string> args = new List<string>();

	public CommandBuilder(string command, string argumentPrefix = "--")
	{
		this.command = command;
		this.argumentPrefix = argumentPrefix;
	}

	public string Build()
	{
		return args.Aggregate(command, (c, arg) => $"{c} {arg}");
	}

	public CommandBuilder With<T>(string parameterName, T parameterValue)
	{
		args.Add($"{this.argumentPrefix}{parameterName} \"{parameterValue}\"");
		return this;
	}

	public CommandBuilder With(string parameterName)
	{
		args.Add($"{this.argumentPrefix}{parameterName}");
		return this;
	}
	
	public CommandBuilder WithRawValue<T>(string parameterName, T parameterValue)
	{
		args.Add($"{this.argumentPrefix}{parameterName} {parameterValue}");
		return this;
	}
}