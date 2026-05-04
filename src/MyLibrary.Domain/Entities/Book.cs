using System;

namespace MyLibrary.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }
    public  required string Title { get; set; }
    public required string Author { get; set; }
}
