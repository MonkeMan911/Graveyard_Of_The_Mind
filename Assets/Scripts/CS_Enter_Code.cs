using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UI.Extensions;
using UnityEngine.Windows;

public class CS_Enter_Code : MonoBehaviour
{
    [SerializeField] CS_Passcode_Check passcode_Check;
    [SerializeField] InputFieldEnterSubmit inputFieldEnterSubmit;
    [SerializeField] InputField inputField;
    void Start()
    {

    }
    void Update()
    {
        passcode_Check.inputT = inputField.text;
    }

    public void ClickNum(string enteredChar)
    {
        string tempString = inputField.text; 
        string newTempString = tempString + enteredChar;
        inputField.text = newTempString;
    }

    public void ClearNumPad() 
    {
        string tempGetString = inputField.text;
        if (tempGetString.Length > 0) 
        {
            string tempString = tempGetString.Remove(0, tempGetString.Length);
            inputField.text = tempString;
        }
    }
    public void EnterNumPad() 
    {
        GrabFromInputField(passcode_Check.inputT);
    }
    public void GrabFromInputField(string input)
    {
        passcode_Check.inputT = input;
        passcode_Check.DisplayInput();
    }
}
