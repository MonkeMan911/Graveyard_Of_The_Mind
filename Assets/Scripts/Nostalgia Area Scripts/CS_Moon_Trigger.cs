using System.Collections;
using UnityEngine;

public class CS_Moon_Trigger : MonoBehaviour
{
    [SerializeField] float cdTime = 0.8f;
    [SerializeField] Animator moonAnimator;
    [SerializeField] float timesStood = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            moonAnimator.SetInteger("Highlight", 1);
            StartCoroutine(QuickCD());
            timesStood++;
        }
    }

    IEnumerator QuickCD()
    {
        yield return new WaitForSeconds(cdTime);
        moonAnimator.SetInteger("Highlight", 0);
    }
}
