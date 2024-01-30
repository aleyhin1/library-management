using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    public List<Book> Books  = new List<Book>();
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

    private void AddBookToLibrary(string title, string author, string isbn, int copycount)
    {
        Book bookToAdd = new Book(title, author, isbn, copycount);
        Books.Add(bookToAdd);
        _UIManager.AddBookPanelToLibraryPopup(title, author, isbn, copycount);
    }
}
