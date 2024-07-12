using Library.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Library.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class LibraryController : AbpControllerBase
{
    protected LibraryController()
    {
        LocalizationResource = typeof(LibraryResource);
    }
}
