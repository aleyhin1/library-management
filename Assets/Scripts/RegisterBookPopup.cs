using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RegisterBookPopup : MonoBehaviour
{
    [SerializeField] private FeedbackPopup _feedbackPopup;
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

        if (titleInput.Length == 0 || titleInput.Length > 50)
        {
            _feedbackPopup.ThrowFeedback("Please provide a Title in the range of 1 and 50 characters.\n" +
                "Example: Crime and Punishment");
            CleanField(_titleInputField);
        }
        else if (!authorInput.All(c => char.IsLetter(c)))
        {
            _feedbackPopup.ThrowFeedback("Author Name should only consist of A-Z characters.\n" +
                "Example: Fyodor Dostoyevski");
            CleanField(_authorInputField);
        }
        else if (authorInput.Length == 0 || authorInput.Length > 50)
        {
            _feedbackPopup.ThrowFeedback("Please provide a Author Name in the range of 1 and 50 characters.\n" +
                "Example: Fyodor Dostoyevski");
            CleanField(_authorInputField);
        }
        else if (!isbnInput.All(c => char.IsDigit(c)))
        {
            _feedbackPopup.ThrowFeedback("ISBN should only consist of digits.\n" +
                "Example: 6548972156985");
            CleanField(_isbnInputField);
        }
        else if (isbnInput.Length != 13 && isbnInput.Length != 10)
        {
            _feedbackPopup.ThrowFeedback("ISBN should be 13 digits or 10 digits.\n" +
                "Example: 9642548964\n" +
                "Example: 4596387124968");
            CleanField(_isbnInputField);
        }
        else if (!inStockInput.All(c => char.IsDigit(c)))
        {
            _feedbackPopup.ThrowFeedback("In Stock can only contain digits.\n" +
                "Example: 32");
            CleanField(_inStockInputField);
        }
        else if (int.Parse(inStockInput) < 1 || int.Parse(inStockInput) > 99)
        {
            _feedbackPopup.ThrowFeedback("In Stock must be in the range of 1 and 100\n" +
                "Example: 55");
            CleanField(_inStockInputField);
        }
        else
        {
            _libraryManager.AddBookToLibrary(titleInput, authorInput, isbnInput, int.Parse(inStockInput));
            _feedbackPopup.ThrowFeedback("Register Successfull");
            CleanFields();
            gameObject.SetActive(false);
        }
    }

    private void CleanFields()
    {
        CleanField(_titleInputField);
        CleanField(_authorInputField);
        CleanField(_isbnInputField);
        CleanField(_inStockInputField);
    }

    private void CleanField(TMP_InputField field)
    {
        field.text = string.Empty;
    }
}
