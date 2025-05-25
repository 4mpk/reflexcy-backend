using MohaProject.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MohaProject.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MohaProjectEntityFrameworkCoreModule),
    typeof(MohaProjectApplicationContractsModule)
    )]
public class MohaProjectDbMigratorModule : AbpModule
{
}
