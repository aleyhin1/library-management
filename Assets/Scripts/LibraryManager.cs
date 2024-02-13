using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    public const double BORROW_TIME = 15;
    private List<Book> _books = new List<Book>();
    [SerializeField] private UIManager _UIManager;

    public void Start()
    {   
        PopulateTheLibrary();
    }

    private void PopulateTheLibrary()
    {
        AddBookToLibrary("Crime and Punishment", "Dostoyevski", "978-0-330-25864-7", 50);
        AddBookToLibrary("The Three Musketeers", "Alexandre Dumas", "232-4-234-5942-1", 55);
        AddBookToLibrary("Sonnets", "William Shakespeare", "523-5-634-1234-5", 24);
        AddBookToLibrary("The Captain's Daughter", "Alexander Pushkin", "534-5-525-6712-3", 23);
        AddBookToLibrary("White Fang", "Jack London", "978-0-06-112008-4", 2);
        AddBookToLibrary("Faust", "Goethe", "978-0-7432-7356-5", 88);
    }

    public void AddBookToLibrary(string title, string author, string isbn, int copyCount)
    {
        Book bookToAdd = new Book(title, author, isbn, copyCount);
        _books.Add(bookToAdd);
        _UIManager.AddBookToLibrary(title, author, isbn, copyCount);
    }

    public void BorrowBook()
    {
        Book bookToBorrow = FindBookByISBN(UIManager.SelectedBookISBN);
        bookToBorrow.Borrow();
        _UIManager.AddBookToMyBooks(bookToBorrow.Title, bookToBorrow.Author, bookToBorrow.Isbn,
            bookToBorrow.BorrowDate.Value, bookToBorrow.DueDate.Value);
    }

    public void ReturnBook()
    {
        Book bookToReturn = FindBookByISBN(UIManager.SelectedBookISBN);
        bookToReturn.Return();
        _UIManager.RemoveBorrowedBookPanel();
    }

    private Book FindBookByISBN(string isbn)
    {
        return _books.Find(book => book.Isbn == isbn);
    }
}
