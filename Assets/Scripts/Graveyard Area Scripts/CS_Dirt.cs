using UnityEngine;

public class CS_Dirt : MonoBehaviour, IDestrucable
{
    public void DestroyDirt() 
    {
        Destroy(this.gameObject);
    }
}
