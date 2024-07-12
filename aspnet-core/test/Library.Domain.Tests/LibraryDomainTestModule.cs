using Volo.Abp.Modularity;

namespace Library;

[DependsOn(
    typeof(LibraryDomainModule),
    typeof(LibraryTestBaseModule)
)]
public class LibraryDomainTestModule : AbpModule
{

}
