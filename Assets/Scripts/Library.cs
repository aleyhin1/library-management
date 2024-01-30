using System.Collections.Generic;

public static class Library
{
    public static List<Book> Books  = new List<Book>();

    public static void AddBookToLibrary(string title, string author, string isbn, int copycount)
    {
        Book bookToAdd = new Book(title, author, isbn, copycount);
        Books.Add(bookToAdd);
    }
}
