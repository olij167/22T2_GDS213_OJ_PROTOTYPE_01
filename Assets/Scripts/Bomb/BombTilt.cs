using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTilt : MonoBehaviour
{
    public float counterMovementSpeed, tiltSpeed, maxTiltSpeed;
    public float maxBombAngle, minBombAngle, leftTiltAngle, rightTiltAngle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        //Debug.Log("Z Rotation = " + transform.rotation.eulerAngles.z);
        
        // lean to the right momentum
        if (transform.eulerAngles.z > minBombAngle && transform.eulerAngles.z < rightTiltAngle)
        {
            tiltSpeed = Mathf.Pow(0.5f + ((360 - transform.eulerAngles.z) / maxBombAngle), 2) * maxTiltSpeed;
            transform.Rotate(0, 0, Vector3.back.z * tiltSpeed * Time.deltaTime);
        }
        
        // lean to the left momentum
        if (transform.eulerAngles.z < maxBombAngle && transform.eulerAngles.z > leftTiltAngle)
        {
            tiltSpeed = Mathf.Pow(0.5f + (transform.eulerAngles.z / maxBombAngle), 2) * maxTiltSpeed;
            transform.Rotate(0, 0, Vector3.forward.z * tiltSpeed * Time.deltaTime);
        }

        // balanced (no momentum)
        if (transform.eulerAngles.z < leftTiltAngle || transform.eulerAngles.z > rightTiltAngle)
        {
            tiltSpeed = 0f;
        }
    }

    public void PlayerMovement()
    {
        // check if player is moving left or right
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, 0, Input.GetAxisRaw("Horizontal") * counterMovementSpeed);
        }

        if (Input.GetAxisRaw("Mouse X") != 0)
        {
            transform.Rotate(0, 0, Input.GetAxisRaw("Mouse X") * counterMovementSpeed);
        }

        // drop the bomb if it leans too far
        if (transform.rotation.eulerAngles.z < minBombAngle && transform.eulerAngles.z > maxBombAngle)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
        }
    }
}
