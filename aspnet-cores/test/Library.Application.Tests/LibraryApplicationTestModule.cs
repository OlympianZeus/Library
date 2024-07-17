using Volo.Abp.Modularity;

namespace Library;

[DependsOn(
    typeof(LibraryApplicationModule),
    typeof(LibraryDomainTestModule)
)]
public class LibraryApplicationTestModule : AbpModule
{

}
