using TMPro;
using UnityEngine;

public class GazeSwipeKeyboardHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public float firstLetterGazeTime = 2.0f; 
    public float subsequentLetterGazeTime = 0.5f;
    private float gazeTimer = 0.0f;
    private bool isFirstLetter = true;

    private string currentGazedLetter;
    private string lastGazedLetter;

    void Update()
    {
        if (currentGazedLetter != null)
        {
            gazeTimer += Time.deltaTime;

            if (isFirstLetter && gazeTimer >= firstLetterGazeTime)
            {
                AddCharacter(currentGazedLetter);
                isFirstLetter = false;
                gazeTimer = 0.0f;
            }
            else if (!isFirstLetter && gazeTimer >= subsequentLetterGazeTime)
            {
                if (currentGazedLetter != lastGazedLetter)
                {
                    AddCharacter(currentGazedLetter);
                    lastGazedLetter = currentGazedLetter;
                }
                gazeTimer = 0.0f;
            }
        }
        else
        {
            gazeTimer = 0.0f;
        }
    }

    
    public void OnGazeStart(string letter)
    {
        currentGazedLetter = letter;
    }

    
    public void OnGazeEnd()
    {
        currentGazedLetter = null;
    }

    private void AddCharacter(string character)
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
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1); // Remove the last character
        }
    }
}