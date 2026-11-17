using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player_Movement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;
    [SerializeField] bool isSneak;
    [SerializeField] GameObject player;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float z = Input.GetAxis("Vertical") * verticalSpeed;
        float x = Input.GetAxis("Horizontal") * horizontalSpeed;

        z *= Time.deltaTime;
        x *= Time.deltaTime;

        transform.Translate(x, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(new Vector3(0, 10, 0));
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.Translate(new Vector3(0, -10, 0));
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            isSneak = true;
        }
        else
        {
            isSneak = false;
        }
        if (isSneak)
        {
            Sneaking();
        }
        else
        {
            NotSneaking();
        }
       
    }

    public void Sneaking()
    {
        player.transform.localScale = new Vector3(1, 0.5f, 1);
    }
    public void NotSneaking()
    {
        player.transform.localScale = new Vector3(1, 1, 1);
    }
}