using System;
using MyLibrary.Application.DTOs;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Application.Services.Interfaces;

public interface IBookService
{
    Book Addbook(BookDTO bookDto);
    List<Book> GetBooks(string? title, string? author);
    Book? UpdateBook(Guid id, BookDTO bookDto);
    bool DeleteBook(Guid id);
}
