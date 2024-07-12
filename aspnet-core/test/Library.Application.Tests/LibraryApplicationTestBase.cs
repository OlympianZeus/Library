using Volo.Abp.Modularity;

namespace Library;

public abstract class LibraryApplicationTestBase<TStartupModule> : LibraryTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
