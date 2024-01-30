using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform _libraryPopupContent;
    [SerializeField] private BookPanel _bookPrefab;

    public void AddBookPanelToLibraryPopup(string title, string author, string isbn, int copyCount)
    {
        BookPanel bookPanel = Instantiate<BookPanel>(_bookPrefab, _libraryPopupContent);
        bookPanel.Init(title, author, isbn, copyCount);
    }
}
