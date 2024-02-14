using System;
using System.Collections.Generic;

[Serializable]
public class Book
{
    public string Title;
    public string Author;
    public string Isbn;
    public string BorrowDate;
    public string DueDate;
    public int CopyCount;

    public Book(string title, string author, string isbn, int copyCount)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        CopyCount = copyCount;
    }

    public Book(string title, string author, string isbn, int copyCount, string borrowDate, string dueDate)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        BorrowDate = borrowDate;
        DueDate = dueDate;
        CopyCount = copyCount;
    } 

    public void Borrow()
    {
        BorrowDate = DateTime.Now.ToString();
        DueDate = DateTime.Now.AddDays(LibraryManager.BORROW_TIME).ToString();
        CopyCount--;
    }

    public void Return()
    {
        BorrowDate = null;
        DueDate = null;
        CopyCount++;
    }
}
