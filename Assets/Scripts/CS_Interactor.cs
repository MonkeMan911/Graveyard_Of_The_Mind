using UnityEngine;

public class CS_Interactor : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float interactDis;
    RaycastHit hitInfo;
    void Start()
    {

    }

    void Update()
    {
        //RayCast Debug
        Ray ray = new Ray(playerCam.position, playerCam.forward);
        if (Physics.Raycast(ray, out hitInfo, interactDis, layerMask))
        {
            Debug.DrawRay(playerCam.position, playerCam.forward * hitInfo.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(playerCam.position, playerCam.forward * hitInfo.distance, Color.red);
        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            PlayerInteract();
        }
    }

    void PlayerInteract() 
    {
        Ray ray = new Ray(playerCam.position, playerCam.forward);
        if (!Physics.Raycast(ray, out RaycastHit hitInfo, interactDis))
        {
            return;
        }

        if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactableObject)) 
        {
            interactableObject.Interact();
        }
    }
}
