using Volo.Abp.Modularity;

namespace MohaProject;

/* Inherit from this class for your domain layer tests. */
public abstract class MohaProjectDomainTestBase<TStartupModule> : MohaProjectTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
