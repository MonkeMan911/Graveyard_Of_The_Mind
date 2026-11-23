using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UI.Extensions;

public class CS_Enter_Code : MonoBehaviour
{
    [SerializeField] InputFieldEnterSubmit inputFieldEnterSubmit;
    [SerializeField] TMP_InputField inputField;
    void Start()
    {

    }
    void Update()
    {

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

    }
}
