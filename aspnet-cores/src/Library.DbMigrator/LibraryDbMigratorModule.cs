using Library.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Library.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LibraryEntityFrameworkCoreModule),
    typeof(LibraryApplicationContractsModule)
    )]
public class LibraryDbMigratorModule : AbpModule
{
}
