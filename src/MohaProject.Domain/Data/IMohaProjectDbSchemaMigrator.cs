using System.Threading.Tasks;

namespace MohaProject.Data;

public interface IMohaProjectDbSchemaMigrator
{
    Task MigrateAsync();
}
