using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BorrowedBookPanel : MonoBehaviour
{
    public event Action<BorrowedBookPanel> OnPanelSelected;
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public DateTime BorrowedTime { get; private set; }
    public DateTime DueTime { get; private set; }
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _authorText;
    [SerializeField] private TextMeshProUGUI _ISBNText;
    [SerializeField] private TextMeshProUGUI _borrowedTimeText;
    [SerializeField] private TextMeshProUGUI _dueTimeText;
    [SerializeField] private Image _image;

    public void Init(string title, string author, string isbn, DateTime borrowedTime, DateTime dueTime)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        BorrowedTime = borrowedTime;
        DueTime = dueTime;

        _titleText.text = title;
        _authorText.text = author;
        _ISBNText.text = isbn;
        _borrowedTimeText.text = borrowedTime.ToLongDateString();
        _dueTimeText.text = dueTime.ToLongDateString();

        DetermineOutOfDate(dueTime);
    }

    public void SelectBook()
    {
        OnPanelSelected.Invoke(this);
    }

    private void DetermineOutOfDate(DateTime dueTime)
    {
        if(DateTime.Now.CompareTo(dueTime) > 0)
        {
            _image.color = Color.red;
        }
    }
}
