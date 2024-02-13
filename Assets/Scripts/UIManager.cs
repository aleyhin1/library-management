using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static string SelectedBookISBN;
    [SerializeField] private RectTransform _libraryPopupContent;
    [SerializeField] private RectTransform _myBooksPopupContent;
    [SerializeField] private TransactionPopup _borrowPopup;
    [SerializeField] private TransactionPopup _returnPopup;
    [SerializeField] private BookPanel _bookPrefab;
    [SerializeField] private BorrowedBookPanel _borrowedBookPrefab;
    private List<BookPanel> _bookPanels = new List<BookPanel>();
    private List<BorrowedBookPanel> _borrowedBookPanels = new List<BorrowedBookPanel>();

    public void AddBookPanelToLibraryPopup(string title, string author, string isbn, int copyCount)
    {
        BookPanel bookPanel = Instantiate<BookPanel>(_bookPrefab, _libraryPopupContent);
        bookPanel.Init(title, author, isbn, copyCount);
        _bookPanels.Add(bookPanel);


        bookPanel.OnPanelSelected += OnBookPanelSelected;
    }

    public void AddBorrowedBookPanelToMyBooksPopup(string title, string author, string isbn, DateTime borrowedTime, DateTime dueTime)
    {
        BorrowedBookPanel borrowedBookPanel = Instantiate<BorrowedBookPanel>(_borrowedBookPrefab, _myBooksPopupContent);
        borrowedBookPanel.Init(title, author, isbn, borrowedTime, dueTime);
        _borrowedBookPanels.Add(borrowedBookPanel);

        borrowedBookPanel.OnPanelSelected += OnBorrowedBookPanelSelected;
    }

    public void RemoveBorrowedBookPanel()
    {
        BorrowedBookPanel panelToRemove = FindBorrowedBookPanelByISBN(SelectedBookISBN);
        _borrowedBookPanels.Remove(panelToRemove);
        Destroy(panelToRemove.gameObject);
    }
    
    public void SearchByTitle(string title)
    {
        SetActiveOnBookPanels(_bookPanels, false);

        var booksWanted = _bookPanels.Where(x => x.Title.ToLower().Contains(title.ToLower()));

        SetActiveOnBookPanels(booksWanted, true);
    }

    public void SearchByAuthor(string author)
    {
        SetActiveOnBookPanels(_bookPanels, false);

        var booksWanted = _bookPanels.Where(x => x.Author.ToLower().Contains(author.ToLower()));

        SetActiveOnBookPanels(booksWanted, true);
    }

    public void OnBookPanelSelected(BookPanel selectedBook)
    {
        SelectedBookISBN = selectedBook.ISBN;
        _borrowPopup.gameObject.SetActive(true);
        _borrowPopup.UpdatePopup(selectedBook.Title, selectedBook.Author, selectedBook.ISBN);
    }

    public void OnBorrowedBookPanelSelected(BorrowedBookPanel selectedBook)
    {
        SelectedBookISBN = selectedBook.ISBN;
        _returnPopup.gameObject.SetActive(true);
        _returnPopup.UpdatePopup(selectedBook.Title, selectedBook.Author, selectedBook.ISBN,
            selectedBook.BorrowedTime, selectedBook.DueTime);
    }

    public void DecreaseInStockOfSelectedBook()
    {
        BookPanel SelectedBook = FindBookPanelByISBN(SelectedBookISBN);
        SelectedBook.DecreaseInStock();
    }

    public void IncreaseInStockOfSelectedBook()
    {
        BookPanel SelectedBook = FindBookPanelByISBN(SelectedBookISBN);
        SelectedBook.IncreaseInStock();
    }

    private void SetActiveOnBookPanels(IEnumerable<BookPanel> panelsToSet, bool status)
    {
        foreach(BookPanel bookPanel in panelsToSet)
        {
            bookPanel.gameObject.SetActive(status);
        }
    }

    private BookPanel FindBookPanelByISBN(string isbn)
    {
        return _bookPanels.Find(bookPanel => bookPanel.ISBN == isbn);
    }

    private BorrowedBookPanel FindBorrowedBookPanelByISBN(string isbn)
    {
        return _borrowedBookPanels.Find(borrowedBookPanel => borrowedBookPanel.ISBN == isbn);
    }
}
