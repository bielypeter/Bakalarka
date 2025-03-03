using TMPro;
using UnityEngine;

public class VirtualKeyboardHandler : MonoBehaviour {
    public TMP_InputField inputField;

    public void AddCharacter(string character)
    {
        if (inputField != null)
        {
            inputField.text += character; 
        }
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