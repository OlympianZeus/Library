using JetBrains.Annotations;
using Volo.Abp;

namespace Library.Authors
{
    public class AuthorAlreadyExistsException: BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(LibraryDomainErrorCodes.AuthorAlreadyExists) 
        {
            WithData("name", name);
        }
    }
}
