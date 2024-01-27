using System.Collections.Generic;

public class Book
{
    private class BookCopy
    {
        bool isBorrowed;
        string borrowDate;
    }

    private string _title;
    private string _author;
    private int _isbn;
    private int _copyCount;
    private List<BookCopy> _copies;

    public Book(string title, string author, int isbn, int copyCount, int borrowedCopies)
    {
        _title = title;
        _author = author;
        _isbn = isbn;
        _copyCount = copyCount;

        CreateCopies(copyCount);
    }

    private void CreateCopies(int copyCount)
    {
        _copies = new List<BookCopy>();

        for (int i = 0; i < copyCount; i++)
        {
            BookCopy copy = new BookCopy();
            _copies.Add(copy);
        }
    }
}
