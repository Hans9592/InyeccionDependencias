using System;
using MyLibrary.Application.DTOs;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Application.Services;

public class BookService
{
   private List<Book>  _books;

   public BookService()
   {
        _books = new List<Book>();
   }

   public Book AddBook(BookDTO bookDto)
   {
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Title = bookDto.Title,
            Author = bookDto.Author
        };

        _books.Add(book);
        return book;
   }
   
   public List<Book> GetBooks(string? title = null, string? author = null)
    {
        var query = _books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
        {
            query = query.Where(book =>
                book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(author))
        {
            query = query.Where(book =>
                book.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
        }

        return query.ToList();
    }

    public Book? UpdateBook(Guid id, BookDTO bookDto)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null) return null;

        book.Title = bookDto.Title;
        book.Author = bookDto.Author;

        return book;
    }

    public bool DeleteBook(Guid id)
    {
        var book = _books.FirstOrDefault(book => book.Id == id);

        if (book == null)
        {
            return false;
        }

        _books.Remove(book);
        return true;
    }
}
