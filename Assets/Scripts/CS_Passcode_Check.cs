using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CS_Passcode_Check : MonoBehaviour
{
    [SerializeField] public string inputT;
    [SerializeField] public string passcode;

    [SerializeField] private GameObject gO;
    [SerializeField] private Text reactionText;
    [SerializeField] private Text hiddenPasscodeText;
    [SerializeField] private UnityEvent correctPass;
    [SerializeField] private UnityEvent incorrectPass;

    private void Start()
    {
        passcode = Random.Range(1000, 9999).ToString();
        hiddenPasscodeText.text = passcode;
    }

    public void DisplayInput() 
    {
        if (inputT == passcode)
        {
            reactionText.text = "Correct passcode " + inputT + "!";
            gO.SetActive(true);
            correctPass.Invoke();
        }
        else 
        {
            gO.SetActive(true);
            reactionText.text = "Incorrect answer try again!";
            incorrectPass.Invoke();
        }
    }
}
