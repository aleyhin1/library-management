using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Isbn { get; private set; }
    public DateTime BorrowDate { get; private set; }
    public DateTime DueDate { get; private set; }
    private int _copyCount;

    public Book(string title, string author, string isbn, int copyCount)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        _copyCount = copyCount;
    }

    public void Borrow()
    {
        BorrowDate = DateTime.Now;
        DueDate = BorrowDate.AddDays(LibraryManager.BorrowTime);
        _copyCount--;
    }
}
