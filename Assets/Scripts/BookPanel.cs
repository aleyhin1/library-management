using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookPanel : MonoBehaviour
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _authorText;
    [SerializeField] private TextMeshProUGUI _ISBNText;
    [SerializeField] private TextMeshProUGUI _inStockText;

    public void Init(string title, string author, string isbn, int instock)
    {
        _titleText.text = title;
        _authorText.text = author;
        _ISBNText.text = isbn;
        _inStockText.text = instock.ToString();

        Title = title;
        Author = author;
    }
}
