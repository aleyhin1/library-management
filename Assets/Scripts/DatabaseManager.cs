using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private void Awake()
    {
        if (!File.Exists(Application.dataPath + "\\SaveFile.json"))
        {
            PopulateTheLibrary();
        }
    }

    private void PopulateTheLibrary()
    {
        BookDatabase bookDatabase = new BookDatabase();

        AddBookToDatabase(bookDatabase, "Crime and Punishment", "Dostoyevski", "9412043915203", 46);
        AddBookToDatabase(bookDatabase, "The Three Musketeers", "Alexandre Dumas", "232423459421", 55);
        AddBookToDatabase(bookDatabase, "Sonnets", "William Shakespeare", "523563412345", 24);
        AddBookToDatabase(bookDatabase, "The Captain's Daughter", "Alexander Pushkin", "534552567123", 23);
        AddBookToDatabase(bookDatabase, "White Fang", "Jack London", "978061120084", 2);
        AddBookToDatabase(bookDatabase, "Faust", "Goethe", "9780743273565", 88);

        AddBorrowedBookToDatabase(bookDatabase, "The Fault in Our Stars", "John Green", "9780525478812", 42, 
            DateTime.Now.AddDays(-30));
        AddBorrowedBookToDatabase(bookDatabase, "The Great Gatsby", "F.Scott Fitzgerald", "9780743273565", 19,
            DateTime.Now.AddDays(-4));
        AddBorrowedBookToDatabase(bookDatabase, "To Kill a Mockingbird", "Harper Lee", "9780061120084", 73,
            DateTime.Now.AddDays(-19));
        AddBorrowedBookToDatabase(bookDatabase, "1984", "George Orwell", "9780451524935", 88,
            DateTime.Now.AddDays(-14));

        string jsonString = JsonUtility.ToJson(bookDatabase);
        File.AppendAllText(Application.dataPath + "\\SaveFile.json", jsonString);
    }

    private void AddBookToDatabase(BookDatabase bookDatabase,string title, string author, string isbn, int copyCount)
    {
        Book bookToAdd = new Book(title, author, isbn, copyCount);
        bookDatabase.Books.Add(bookToAdd);
    }

    private void AddBorrowedBookToDatabase(BookDatabase bookDatabase, string title, string author, string isbn, int copyCount,
        DateTime borrowedDate)
    {
        Book bookToAdd = new Book(title, author, isbn, copyCount, borrowedDate.ToString(),
            borrowedDate.AddDays(LibraryManager.BORROW_TIME).ToString());
        bookDatabase.Books.Add(bookToAdd);
    }
}
