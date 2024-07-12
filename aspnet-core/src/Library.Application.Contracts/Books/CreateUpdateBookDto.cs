using Library.Books;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Books;

//This DTO class is used to get a book information from the user interface while creating or updating the book
public class CreateUpdateBookDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public BookType Type { get; set; } = BookType.Undefined;

    [Required]
    [DataType(DataType.Date)]
    public DateTime PublishDate { get; set; } = DateTime.Now;

    [Required]
    public float Price { get; set; }

    public Guid AuthorId { get; set; }
}
