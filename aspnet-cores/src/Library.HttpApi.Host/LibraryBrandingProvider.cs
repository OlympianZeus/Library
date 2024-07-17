using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Library;

[Dependency(ReplaceServices = true)]
public class LibraryBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Library";
}
