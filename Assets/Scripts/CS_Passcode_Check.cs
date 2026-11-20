using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CS_Passcode_Check : MonoBehaviour
{
    [SerializeField] private string inputT;
    [SerializeField] private string passcode;

    [SerializeField] private GameObject gO;
    [SerializeField] private TMP_Text reactionText;
    [SerializeField] private TMP_Text hiddenPasscodeText;
    [SerializeField] private UnityEvent correctPass;
    [SerializeField] private UnityEvent incorrectPass;

    private bool bIsPasscodeCorrect;

    private void Start()
    {
        passcode = Random.Range(1000, 9999).ToString();
        hiddenPasscodeText.text = passcode;
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
            reactionText.text = "Correct passcode " + inputT + "!";
            gO.SetActive(true);
            bIsPasscodeCorrect = true;
            correctPass.Invoke();
        }
        else 
        {
            gO.SetActive(true);
            reactionText.text = "Incorrect answer try again!";
            bIsPasscodeCorrect = false;
            incorrectPass.Invoke();
        }
    }
}
