using Volo.Abp.Modularity;

namespace MohaProject;

[DependsOn(
    typeof(MohaProjectApplicationModule),
    typeof(MohaProjectDomainTestModule)
)]
public class MohaProjectApplicationTestModule : AbpModule
{

}
