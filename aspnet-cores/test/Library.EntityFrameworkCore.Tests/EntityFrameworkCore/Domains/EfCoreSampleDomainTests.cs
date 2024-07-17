using Library.Samples;
using Xunit;

namespace Library.EntityFrameworkCore.Domains;

[Collection(LibraryTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<LibraryEntityFrameworkCoreTestModule>
{

}
