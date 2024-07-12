using Volo.Abp.Modularity;

namespace Library;

/* Inherit from this class for your domain layer tests. */
public abstract class LibraryDomainTestBase<TStartupModule> : LibraryTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
