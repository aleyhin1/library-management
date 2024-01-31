using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform _libraryPopupContent;
    [SerializeField] private BookPanel _bookPrefab;
    private List<BookPanel> _bookPanels = new List<BookPanel>();

    public void AddBookPanelToLibraryPopup(string title, string author, string isbn, int copyCount)
    {
        BookPanel bookPanel = Instantiate<BookPanel>(_bookPrefab, _libraryPopupContent);
        bookPanel.Init(title, author, isbn, copyCount);
        _bookPanels.Add(bookPanel);
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

    private void SetActiveOnBookPanels(IEnumerable<BookPanel> panelsToSet, bool status)
    {
        foreach(BookPanel bookPanel in panelsToSet)
        {
            bookPanel.gameObject.SetActive(status);
        }
    }
}
