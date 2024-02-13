using System;
using TMPro;
using UnityEngine;

public class TransactionPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleField;
    [SerializeField] private TextMeshProUGUI _authorField;
    [SerializeField] private TextMeshProUGUI _isbnField;
    [SerializeField] private TextMeshProUGUI _borrowDateField;
    [SerializeField] private TextMeshProUGUI _dueDateField;

    public void UpdatePopup(string title, string author, string isbn)
    {
        _titleField.text = title;
        _authorField.text = author;
        _isbnField.text = isbn;
        _borrowDateField.text = DateTime.Now.ToLongDateString();
        _dueDateField.text = DateTime.Now.AddDays(LibraryManager.BorrowTime).ToLongDateString();
    }

    public void UpdatePopup(string title, string author, string isbn, DateTime borrowDate, DateTime dueDate)
    {
        _titleField.text = title;
        _authorField.text = author;
        _isbnField.text = isbn;
        _borrowDateField.text = borrowDate.ToLongDateString();
        _dueDateField.text = dueDate.ToLongDateString();
    }
}
