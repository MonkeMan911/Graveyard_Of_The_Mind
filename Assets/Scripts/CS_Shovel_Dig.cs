using Unity.VisualScripting;
using UnityEngine;

public class CS_Shovel_Dig : MonoBehaviour, IInteractable
{
    [Header("Holding Shovel")]
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform handTransform;
    [SerializeField] Vector3 offset;
    bool bPickUp;
    bool bHoldingShovel;

    [Header("RayCasting")]
    [SerializeField] Transform playerCam;
    [SerializeField] LayerMask dirtLayer;
    [SerializeField] float interactDis;
    RaycastHit hitInfo;
    
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

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            DigWithShovel();
        }
    }

    void DigWithShovel() 
    {
        if (bHoldingShovel == true) 
        {
            Ray shovelRay = new Ray(playerCam.position, playerCam.forward);
            if (!Physics.Raycast(shovelRay, out RaycastHit hitInfo, interactDis)) 
            {
                return;
            }
            if (hitInfo.collider.gameObject.TryGetComponent(out IDestrucable destrucableObject)) 
            {
                destrucableObject.DestroyDirt();
            }
        } 
    }

    public void Interact() 
    {
        bPickUp=true;
    }
}
