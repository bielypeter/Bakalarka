using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class DualGazeKeyboardHandler : MonoBehaviour { 
    public TMP_InputField inputField; 
    public GameObject confirmationElement; 
    public TMP_Text cpmDisplay;
    private string pendingCharacter;
    private float startTime;
    private bool typingStarted = false;
    private int characterCount = 0;

    void Start()
    {
        if (confirmationElement != null) { 
            confirmationElement.SetActive(false);
        }
    } 

    public void ShowConfirmation(string character) { 
        if (confirmationElement != null) { 
            pendingCharacter = character; 
            confirmationElement.SetActive(true);
        }
    }

    public void ConfirmCharacter() { 
        if (inputField != null && pendingCharacter != null) { 
            inputField.text += pendingCharacter; 
            pendingCharacter = null;
            confirmationElement.SetActive(false);
        }
    }

    public void SelectLetter(string letter)
    {
        ShowConfirmation(letter);
    }


    public void ClearInput()
    {
        if (inputField != null)
        {
            inputField.text = "";
        }
    }

    public void Backspace()
    {
        if (inputField != null && inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }
}
