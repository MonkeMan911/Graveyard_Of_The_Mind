using UnityEngine;
using System.Collections;

public class CS_Sun_Trigger : MonoBehaviour
{
    [SerializeField] float cdTime = 0.8f;
    [SerializeField] Animator sunAnimator;
    [SerializeField] float timesStood = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sunAnimator.SetInteger("Highlight", 1);
            StartCoroutine(QuickCD());
            timesStood++;
        }
    }

    IEnumerator QuickCD()
    {
        yield return new WaitForSeconds(cdTime);
        sunAnimator.SetInteger("Highlight", 0);
    }
}
