using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTilt : MonoBehaviour
{
    public PlayerController playerController;
    public float tiltSpeed, maxBombAngle, minBombAngle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        //Debug.Log("Z Rotation = " + transform.rotation.eulerAngles.z);

        //if (transform.eulerAngles.z > minBombAngle && transform.eulerAngles.z < maxBombAngle)
        //{

        //}
    }

    public void PlayerMovement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, 0, Input.GetAxisRaw("Horizontal") * tiltSpeed);
        }

        if (transform.rotation.eulerAngles.z < minBombAngle && transform.eulerAngles.z > maxBombAngle)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
        }
    }
}
