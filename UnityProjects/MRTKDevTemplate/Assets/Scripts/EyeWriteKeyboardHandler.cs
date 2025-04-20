using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EyeWriteSystem : MonoBehaviour
{
    public TMP_InputField inputField;

    private List<string> currentStroke = new();
    private string lastCorner = "";

    // Button ids TL TR BL BR Center
    public void OnCornerPressed(string cornerId)
    {

        if (string.IsNullOrEmpty(cornerId)) return;

        if (cornerId == "Center" && currentStroke.Count > 0)
        {
            string key = string.Join("-", currentStroke);
            char result = RecognizeGesture(key);
            inputField.text += result;
            currentStroke.Clear();
            lastCorner = "";
        }
        else if (cornerId != lastCorner && cornerId != "Center")
        {
            
            currentStroke.Add(cornerId);
            lastCorner = cornerId;
            Debug.Log($"[EyeWrite] Pressed: {cornerId}");
        }
    }

    private char RecognizeGesture(string gestureKey)
    {
        if (gestureAlphabet.TryGetValue(gestureKey, out char letter))
            return letter;
        if (digitGestures.TryGetValue(gestureKey, out char digit))
            return digit;
        return '?';
    }

    public void ClearInput()
    {
        if (inputField != null)
            inputField.text = "";
    }

    public void Backspace()
    {
        if (inputField != null && inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }

    // EyeWrite Alphabet from paper
    private static readonly Dictionary<string, char> gestureAlphabet = new()
{
    { "TL-TR-BR", 'T' },
    { "BL-TR-BR", 'A' },
    { "TL-BL-BR-BL", 'B' },
    { "TR-TL-BL-BR", 'C' },
    { "TR-BR-BL-BR", 'D' },
    { "TL-TR-TL-BL-BR", 'E' },
    { "TR-TL-BL", 'F' },
    { "TR-TL-TR-BR-BL", 'G' },
    { "TL-BL-TR-BR", 'H' },
    { "TL-BL", 'I' },
    { "TR-BR-BL", 'J' },
    { "TL-BL-TR-BL-BR", 'K' },
    { "TL-BL-BR", 'L' },
    { "BL-TL-BR-TR-BR", 'M' },
    { "BL-TL-BR-TR", 'N' },
    { "TR-TL-BL-BR-TR", 'O' },
    { "TL-TR-TL-BL", 'P' },
    { "TR-TL-TR-BR-TR", 'Q' },
    { "BL-TL-TR", 'R' },
    { "TR-TL-BR-BL", 'S' },
    { "TL-BL-BR-TR", 'U' },
    { "TL-BL-TR", 'V' },
    { "TL-BL-TR-BR-TR", 'W' },
    { "TL-BR-TR-BL", 'X' },
    { "TL-BR-TR-BR", 'Y' },
    { "TL-TR-BL-BR", 'Z' },
    { "TR-TL", ' ' } // Space
};


    // Digit gestures (custom)
    private static readonly Dictionary<string, char> digitGestures = new()
{
    { "TL-TR", '1' },
    { "TL-TR-TL", '2' },
    { "TL-TR-BL-TR-BR", '3' },
    { "TL-BL-TR-BR-TL", '4' },
    { "TR-TL-BL-BR-BL", '5' },
    { "TR-TL-BL-BR-TR-BL", '6' },
    { "TL-TR-BL", '7' },
    { "TR-TL-BR-BL-TR", '8' },
    { "TR-TL-BL-TR-BR-BL", '9' },
    { "TL-BL-BR-TR-TL", '0' }
};

}
