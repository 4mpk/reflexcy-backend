using Volo.Abp.Modularity;

namespace MohaProject;

[DependsOn(
    typeof(MohaProjectDomainModule),
    typeof(MohaProjectTestBaseModule)
)]
public class MohaProjectDomainTestModule : AbpModule
{

}
