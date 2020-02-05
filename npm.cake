using Cake.Npm;

Task("Install-NpmPackages")
    .Does(() =>
{
    NpmInstall();
});