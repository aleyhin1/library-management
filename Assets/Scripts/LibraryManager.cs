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
        AddBookToLibrary("Crime and Punishment", "Dostoyevski", "9780330258647", 50);
        AddBookToLibrary("The Three Musketeers", "Alexandre Dumas", "232423459421", 55);
        AddBookToLibrary("Sonnets", "William Shakespeare", "523563412345", 24);
        AddBookToLibrary("The Captain's Daughter", "Alexander Pushkin", "534552567123", 23);
        AddBookToLibrary("White Fang", "Jack London", "978061120084", 2);
        AddBookToLibrary("Faust", "Goethe", "9780743273565", 88);
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
