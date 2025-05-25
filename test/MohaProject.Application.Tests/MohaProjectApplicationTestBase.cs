using Volo.Abp.Modularity;

namespace MohaProject;

public abstract class MohaProjectApplicationTestBase<TStartupModule> : MohaProjectTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
