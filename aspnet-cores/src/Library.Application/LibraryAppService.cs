using System;
using System.Collections.Generic;
using System.Text;
using Library.Localization;
using Volo.Abp.Application.Services;

namespace Library;

/* Inherit your application services from this class.
 */
public abstract class LibraryAppService : ApplicationService
{
    protected LibraryAppService()
    {
        LocalizationResource = typeof(LibraryResource);
    }
}
