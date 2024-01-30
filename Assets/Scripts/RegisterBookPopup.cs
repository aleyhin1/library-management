using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegisterBookPopup : MonoBehaviour
{
    [SerializeField] private LibraryManager _libraryManager;
    [SerializeField] private TMP_InputField _titleInputField;
    [SerializeField] private TMP_InputField _authorInputField;
    [SerializeField] private TMP_InputField _isbnInputField;
    [SerializeField] private TMP_InputField _inStockInputField;

    public void RegisterBook()
    {
        string titleInput = _titleInputField.text;
        string authorInput = _authorInputField.text;
        string isbnInput = _isbnInputField.text;
        string inStockInput = _inStockInputField.text;

        _libraryManager.AddBook(titleInput, authorInput, isbnInput, int.Parse(inStockInput));
    }
}
