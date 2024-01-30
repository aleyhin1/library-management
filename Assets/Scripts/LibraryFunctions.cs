using System.Collections.Generic;

public static class LibraryFunctions
{
    public static void AddBook(List<Book> list, string title, string author, long isbn, int copycount)
    {
        Book bookToAdd = new Book(title, author, isbn, copycount);
        list.Add(bookToAdd);
    }
}
