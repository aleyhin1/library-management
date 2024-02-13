using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedbackPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI FeedbackTextField;

    public void ThrowFeedback(string feedback)
    {
        gameObject.SetActive(true);
        FeedbackTextField.text = feedback;
    }
}
