using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    public static List<Book> Books = new List<Book>();
    [SerializeField] private UIManager _UIManager;

    public void Start()
    {   
        PopulateTheLibrary();
    }

    private void PopulateTheLibrary()
    {
        AddBook("Crime and Punishment", "Dostoyevski", "978-0-330-25864-7", 50);
        AddBook("The Three Musketeers", "Alexandre Dumas", "232-4-234-5942-1", 55);
        AddBook("Sonnets", "William Shakespeare", "523-5-634-1234-5", 24);
        AddBook("The Captain's Daughter", "Alexander Pushkin", "534-5-525-6712-3", 23);
        AddBook("White Fang", "Jack London", "978-0-06-112008-4", 2);
        AddBook("Faust", "Goethe", "978-0-7432-7356-5", 88);
    }

    public void AddBook(string title, string author, string isbn, int copyCount)
    {
        Book bookToAdd = new Book(title, author, isbn, copyCount);
        Books.Add(bookToAdd);
        _UIManager.AddBookPanelToLibraryPopup(title, author, isbn, copyCount);
    }

    public void BorrowBook()
    {
        Book bookToBorrow = FindBookByISBN(UIManager.SelectedBookISBN);
        bookToBorrow.Borrow();
    }

    private Book FindBookByISBN(string isbn)
    {
        return Books.Find(book => book.Isbn == isbn);
    }
}
