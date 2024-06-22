namespace CM3070_API.DependencyResolution
{
    public interface IInstaller
    {
        void InstallerServices(IServiceCollection services, IConfiguration configuration);
    }
}
