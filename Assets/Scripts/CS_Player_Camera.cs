using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Camera_Controller : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;

    [SerializeField] Transform playerBody;

    [SerializeField] bool bIsCursorLocked;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        bIsCursorLocked = true;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (bIsCursorLocked)
            {
                UnlockCursor();
                bIsCursorLocked = false;
            }
            else
            {
                LockCursor();
                bIsCursorLocked = true;
            }

        }
    }
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.LogWarning("Locked" + Cursor.lockState);
    }
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.LogWarning("Unlocked" + Cursor.lockState);
    }
}