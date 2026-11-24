using UnityEngine;

public class CS_Shovel_Dig : MonoBehaviour, IInteractable
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform handTransform;
    [SerializeField] Vector3 offset;
    bool bPickUp;
    bool bHoldingShovel;
    void Start()
    {
        bPickUp = false;
        bHoldingShovel = false;
    }

    void Update()
    {
        if (bPickUp) 
        {
            this.transform.position = handTransform.position + offset;
            this.transform.parent = playerTransform;
            bHoldingShovel = true;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            bPickUp = false;
            this.transform.parent = null;
        }
    }

    public void Interact() 
    {
        bPickUp=true;
    }
}
