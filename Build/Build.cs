using GlobalRoam.Build.Fallout;
using Fallout.Common.Execution;

[UnsetVisualStudioEnvironmentVariables]
class Build : NugetPackageBuild
{
	protected override bool IncludeSourceInPack => false;
	protected override bool IncludeSymbolsInPack => false;

	public static int Main() => Execute<Build>(x => x.Test);

}
