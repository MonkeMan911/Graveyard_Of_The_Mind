using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.Rendering.DebugUI;

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
    [SerializeField] Material[] outMaterials;
    [SerializeField] public List<MeshRenderer> outlinedMats = new();
    [SerializeField] bool highlighted;
    [SerializeField] Material regularMat;
    
    void Start()
    {
        bPickUp = false;
        bHoldingShovel = false;
        highlighted = false;
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
        Ray ray = new Ray(playerCam.position, playerCam.forward); //Creates a RayCast from the player 
        if (Physics.Raycast(ray, out hitInfo, interactDis, dirtLayer)) //if RayCast Hits the desired Layer then execute Below
        {
            Debug.DrawRay(playerCam.position, playerCam.forward * hitInfo.distance, Color.green); //Shows Raycast as green in the scene
            if (!highlighted) //if canTp is false then Execute
            {
                HighlightDirt(); //Runs The Teleport Check Function if the RayCast Hits Enemy Layer and canTp == False
                highlighted = true; //sets to true so it cannot be executed again
            }
        }
        else 
        {
            UnHighlight();
        }
    }

    void DigWithShovel() 
    {
        if (bHoldingShovel == true) 
        {
            Ray shovelRay = new Ray(playerCam.position, playerCam.forward);
            if (!Physics.Raycast(shovelRay, out RaycastHit hitInfo, interactDis)) 
            {
                UnHighlight();
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

    public void HighlightDirt()
    {
        Ray shovelRay2 = new Ray(playerCam.position, playerCam.forward);
        if (!Physics.Raycast(shovelRay2, out RaycastHit hitInfo, interactDis)) 
        {
            return;
        }
        Collider[] dirtColliders = hitInfo.collider.gameObject.GetComponents<Collider>();
        foreach (Collider collider in dirtColliders) 
        {
            MeshRenderer meshRenderer = collider.gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.materials = outMaterials;
                outlinedMats.Add(meshRenderer);
            }
        }
    }

    public void UnHighlight() 
    {
        highlighted = false;
        foreach (MeshRenderer rend in outlinedMats) 
        {
            if (rend != null) 
            { 
                Debug.Log("Unhighlighted");
                Material[] materials = new Material[rend.materials.Length];
                materials[0] = regularMat;
                materials[1] = outMaterials[0];
                rend.sharedMaterials = materials;
            }
        }
        outlinedMats.Clear();
    }
}
