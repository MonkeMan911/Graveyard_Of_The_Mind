using UnityEngine;

public class CS_Open_Door_Test : MonoBehaviour
{
    [SerializeField] Vector3 doorSwingVect;
    [SerializeField] float doorSwingAngle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            OpenDoor();
        }
    }

    public void OpenDoor() 
    {
        float topY = 150;
        float bottomY = -150;
        float doorSwingVectY = doorSwingVect.y;
        doorSwingVectY = Mathf.Clamp(doorSwingVectY, topY, bottomY);
        doorSwingVect = new Vector3(0, doorSwingVectY, 0);
        transform.Rotate(doorSwingVect, doorSwingAngle);
    }
}
