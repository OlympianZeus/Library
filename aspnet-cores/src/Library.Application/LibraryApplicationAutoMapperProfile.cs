using Library.Books;
using AutoMapper;
using Library.Authors;

namespace Library;

public class LibraryApplicationAutoMapperProfile : Profile
{
    public LibraryApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
       
        CreateMap<Book, BookDto>();//This code maps the Book Entities to the BookDto
        CreateMap<CreateUpdateBookDto, Book>();//this code maps Book Entities to the CreateUpdate Dto
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();
    }
}
