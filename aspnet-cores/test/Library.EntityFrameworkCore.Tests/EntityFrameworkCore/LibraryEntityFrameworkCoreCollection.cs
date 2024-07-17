using Xunit;

namespace Library.EntityFrameworkCore;

[CollectionDefinition(LibraryTestConsts.CollectionDefinitionName)]
public class LibraryEntityFrameworkCoreCollection : ICollectionFixture<LibraryEntityFrameworkCoreFixture>
{

}
