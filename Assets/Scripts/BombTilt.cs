using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTilt : MonoBehaviour
{
    public PlayerController playerController;
    public float counterMovementSpeed, tiltSpeed, maxBombAngle, minBombAngle, leftTiltAngle, rightTiltAngle, maxTiltSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        //Debug.Log("Z Rotation = " + transform.rotation.eulerAngles.z);
        
        // right heavy
        if (transform.eulerAngles.z > minBombAngle && transform.eulerAngles.z < rightTiltAngle)
        {
            tiltSpeed = Mathf.Pow(0.5f + ((360 - transform.eulerAngles.z) / maxBombAngle), 2) * maxTiltSpeed;
            transform.Rotate(0, 0, Vector3.back.z * tiltSpeed * Time.deltaTime);
        }
        
        // left heavy
        if (transform.eulerAngles.z < maxBombAngle && transform.eulerAngles.z > leftTiltAngle)
        {
            tiltSpeed = Mathf.Pow(0.5f + (transform.eulerAngles.z / maxBombAngle), 2) * maxTiltSpeed;
            transform.Rotate(0, 0, Vector3.forward.z * tiltSpeed * Time.deltaTime);
        }

        // balanced
        if (transform.eulerAngles.z < leftTiltAngle || transform.eulerAngles.z > rightTiltAngle)
        {
            tiltSpeed = 0f;
        }
    }

    public void PlayerMovement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, 0, Input.GetAxisRaw("Horizontal") * counterMovementSpeed);
        }

        if (transform.rotation.eulerAngles.z < minBombAngle && transform.eulerAngles.z > maxBombAngle)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
        }
    }
}
