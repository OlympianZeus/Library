using Library.Samples;
using Xunit;

namespace Library.EntityFrameworkCore.Applications;

[Collection(LibraryTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<LibraryEntityFrameworkCoreTestModule>
{

}
