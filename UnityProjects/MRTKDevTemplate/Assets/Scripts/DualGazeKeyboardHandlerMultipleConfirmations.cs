using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DualGazeKeyboardHandlerMultipleConfirmations : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject[] confirmationElements;
    public TMP_Text cpmDisplay;

    private string pendingCharacter;
    private float startTime;
    private bool typingStarted = false;
    private int characterCount = 0;

    void Start()
    {
        foreach (var element in confirmationElements)
        {
            if (element != null)
                element.SetActive(false);
        }

        if (cpmDisplay != null)
            cpmDisplay.text = "CPM: 0";
    }

    public void ShowConfirmation(string character)
    {
        pendingCharacter = character;

        foreach (var element in confirmationElements)
        {
            if (element != null)
                element.SetActive(true);
        }
    }

    public void SelectLetter(string letter)
    {
        ShowConfirmation(letter);
    }

    public void ConfirmCharacter()
    {
        Debug.Log("ConfirmCharacter() called");


        if (inputField != null && pendingCharacter != null)
        {
            inputField.text += pendingCharacter;
            characterCount++;

            if (!typingStarted)
            {
                typingStarted = true;
                startTime = Time.time;
            }

            UpdateCPMDisplay();

            pendingCharacter = null;

            foreach (var element in confirmationElements)
            {
                if (element != null)
                    element.SetActive(false);
            }
        }
    }

    private void UpdateCPMDisplay()
{
    if (typingStarted && cpmDisplay != null)
    {
        float elapsedMinutes = (Time.time - startTime) / 60f;
        float cpm = elapsedMinutes > 0 ? characterCount / elapsedMinutes : 0f;
        float wpm = elapsedMinutes > 0 ? (characterCount / 5f) / elapsedMinutes : 0f;

        cpmDisplay.text = $"CPM: {cpm:F1} | WPM: {wpm:F1}";
    }
}

    public void ClearInput()
    {
        if (inputField != null)
            inputField.text = "";

        typingStarted = false;
        characterCount = 0;
        if (cpmDisplay != null)
            cpmDisplay.text = "CPM: 0";
    }

    public void Backspace()
    {
        if (inputField != null && inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
            characterCount = Mathf.Max(0, characterCount - 1);
            UpdateCPMDisplay();
        }
    }
}
