// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.NuGet
{
    public static partial class NuGetTasks
    {
        private static string GetToolPath()
        {
            return ToolPathResolver.TryGetEnvironmentExecutable("NUGET_EXE")
                   ?? ToolPathResolver.GetPackageExecutable("NuGet.CommandLine", "nuget.exe");
        }

        [Obsolete("Property will be removed in a following version. Please define it yourself.")]
        public static NuGetPackSettings DefaultNuGetPack => new NuGetPackSettings()
            .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
            .SetOutputDirectory(NukeBuild.Instance.OutputDirectory)
            .SetConfiguration(NukeBuild.Instance.Configuration)
            .SetVersion(GitVersionAttribute.Value?.NuGetVersionV2);

        [Obsolete("Property will be removed in a following version. Please define it yourself.")]
        public static NuGetRestoreSettings DefaultNuGetRestore => new NuGetRestoreSettings()
            .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
            .SetTargetPath(NukeBuild.Instance.SolutionFile);
    }
}