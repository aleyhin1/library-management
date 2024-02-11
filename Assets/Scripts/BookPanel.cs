using System;
using TMPro;
using UnityEngine;

public class BookPanel : MonoBehaviour
{
    public event Action<BookPanel> OnPanelSelected;
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _authorText;
    [SerializeField] private TextMeshProUGUI _ISBNText;
    [SerializeField] private TextMeshProUGUI _inStockText;

    public void Init(string title, string author, string isbn, int instock)
    {
        Title = title;
        Author = author;
        ISBN = isbn;

        _titleText.text = title;
        _authorText.text = author;
        _ISBNText.text = isbn;
        _inStockText.text = instock.ToString();
    }

    public void DecreaseInStock()
    {
        int inStockCount = Int32.Parse(_inStockText.text);
        inStockCount--;
        _inStockText.text = inStockCount.ToString();
    }

    public void SelectBook()
    {
        OnPanelSelected.Invoke(this);
    }
}
