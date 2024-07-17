using Library.Authors;
using Xunit;

namespace Library.EntityFrameworkCore.Applications.Authors;

[Collection(LibraryTestConsts.CollectionDefinitionName)]
public class EfCoreAuthorAppService_Tests : AuthorAppService_Tests<LibraryEntityFrameworkCoreTestModule>
{

}
