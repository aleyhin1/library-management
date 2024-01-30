using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    public List<Book> Books  = new List<Book>();

    public void Start()
    {
        LibraryFunctions.AddBook(Books, "Crime and Punishment", "Dostoyevski", 01234567891234, 3);
        Debug.Log(Books[0].Title);
    }
}
