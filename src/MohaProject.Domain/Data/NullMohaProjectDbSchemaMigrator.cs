using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MohaProject.Data;

/* This is used if database provider does't define
 * IMohaProjectDbSchemaMigrator implementation.
 */
public class NullMohaProjectDbSchemaMigrator : IMohaProjectDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
