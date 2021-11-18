using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RocketMove : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float thrustSpeed = 200.0f;
    [SerializeField] private float rotateSpeed = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ThrustRocket();
        RotateRocket();
    }

    public void ThrustRocket()
    {
        if (CrossPlatformInputManager.GetButton("Thrust"))
        {
               thrustSpeed += 10;
               rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
        else
        {
            thrustSpeed = 1130;
        }
    }

    private void RotateRocket()
    {
        rb.freezeRotation = true;

        if (CrossPlatformInputManager.GetButton("Left"))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
        else if (CrossPlatformInputManager.GetButton("Right"))
        {
            transform.Rotate((-1) * Vector3.forward * rotateSpeed * Time.deltaTime);
        }

        rb.freezeRotation = false;
    }
}
