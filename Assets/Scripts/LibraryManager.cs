using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    public const double BORROW_TIME = 15;
    [HideInInspector] public List<Book> Books = new List<Book>();
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private FeedbackPopup _feedbackPopup;

    public void Start()
    {   
        PopulateTheLibrary();
    }

    private void PopulateTheLibrary()
    {
        foreach(Book book in Books)
        {
            CreateBook(book);
        }
    }

    public void CreateBook(Book book)
    {
        if (book.BorrowDate == string.Empty)
        {
            _UIManager.AddBookPanel(book.Title, book.Author, book.Isbn, book.CopyCount);
        }
        else
        {
            _UIManager.AddBookPanel(book.Title, book.Author, book.Isbn, book.CopyCount);
            _UIManager.AddBorrowedBookPanel(book.Title, book.Author, book.Isbn, DateTime.Parse(book.BorrowDate),
                DateTime.Parse(book.DueDate));
        }
    }

    public void AddBookToLibrary(string title, string author, string isbn, int copyCount)
    {
        Book bookToAdd = new Book(title, author, isbn, copyCount);
        Books.Add(bookToAdd);
        _UIManager.AddBookPanel(title, author, isbn, copyCount);
    }

    public void BorrowBook()
    {
        Book bookToBorrow = FindBookByISBN(UIManager.SelectedBookISBN);

        if (bookToBorrow.BorrowDate != string.Empty)
        {
            _feedbackPopup.ThrowFeedback("You already have this book...");
        }
        else
        {
            bookToBorrow.Borrow();
            _UIManager.AddBorrowedBookPanel(bookToBorrow.Title, bookToBorrow.Author, bookToBorrow.Isbn,
                DateTime.Parse(bookToBorrow.BorrowDate), DateTime.Parse(bookToBorrow.DueDate));
            _UIManager.DecreaseInStockOfSelectedBook();
            _feedbackPopup.ThrowFeedback("You successfully borrowed the book. Enjoy!");
        }
        
    }

    public void ReturnBook()
    {
        Book bookToReturn = FindBookByISBN(UIManager.SelectedBookISBN);
        bookToReturn.Return();
        _UIManager.RemoveBorrowedBookPanel();
        _feedbackPopup.ThrowFeedback("You successfully returned the book. Thanks!");
    }

    private Book FindBookByISBN(string isbn)
    {
        return Books.Find(book => book.Isbn == isbn);
    }
}
