using System.Threading.Tasks;

namespace Library.Data;

public interface ILibraryDbSchemaMigrator
{
    Task MigrateAsync();
}
