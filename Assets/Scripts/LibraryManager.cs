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
    [SerializeField] private FeedbackPopup _feedbackPopup;

    public void Start()
    {   

    }

    private void PopulateTheLibrary()
    {

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

        if (bookToBorrow.BorrowDate != null)
        {
            _feedbackPopup.ThrowFeedback("You already have this book...");
        }
        else
        {
            bookToBorrow.Borrow();
            _UIManager.AddBookToMyBooks(bookToBorrow.Title, bookToBorrow.Author, bookToBorrow.Isbn,
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
        return _books.Find(book => book.Isbn == isbn);
    }
}
