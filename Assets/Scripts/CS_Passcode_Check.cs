using UnityEngine;
using TMPro;

public class CS_Passcode_Check : MonoBehaviour
{
    [SerializeField] private string inputT;
    [SerializeField] private string passcode;

    [SerializeField] private GameObject gO;
    [SerializeField] private TMP_Text reactionText;

    private bool bIsPasscodeCorrect;

    private void Start()
    {
        passcode = Random.Range(1000, 9999).ToString();
    }
    public void GrabFromInputField(string input) 
    {
        inputT = input;
        DisplayInput();
    }

    public void DisplayInput() 
    {
        if (inputT == passcode)
        {
            reactionText.text = "thats right the correct passcode is " + inputT + "!";
            gO.SetActive(true);
            bIsPasscodeCorrect = true;
        }
        else 
        {
            reactionText.text = "incorrect answer the correct answer is " + passcode + "!";
            bIsPasscodeCorrect = false;
        }
    }
}
