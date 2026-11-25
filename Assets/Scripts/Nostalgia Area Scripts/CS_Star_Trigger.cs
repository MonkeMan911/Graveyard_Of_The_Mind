using System.Collections;
using UnityEngine;

public class CS_Star_Trigger : MonoBehaviour
{
    [SerializeField] float cdTime = 0.8f;
    [SerializeField] Animator starAnimator;
    [SerializeField] float timesStood = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            starAnimator.SetInteger("Highlight", 1);
            StartCoroutine(QuickCD());
            timesStood++;
        }
    }
    IEnumerator QuickCD()
    {
        yield return new WaitForSeconds(cdTime);
        starAnimator.SetInteger("Highlight", 0);
    }
}
