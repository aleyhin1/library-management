using System.Collections.Generic;

public class Book
{
    private class BookCopy
    {
        private bool _isBorrowed;
        private string _borrowDate;
    }

    public string Title { get; private set; }
    private string _author;
    private string _isbn;
    private int _copyCount;
    private List<BookCopy> _copies;

    public Book(string title, string author, string isbn, int copyCount)
    {
        Title = title;
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
