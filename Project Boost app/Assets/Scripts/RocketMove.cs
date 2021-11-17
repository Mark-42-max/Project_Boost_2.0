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



    private void ThrustRocket()
    {
        if (CrossPlatformInputManager.GetButtonDown("Thrust"))
        {
            thrustSpeed += 200;
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
    }

    private void RotateRocket()
    {
        if (CrossPlatformInputManager.GetButtonDown("Left"))
        {
            transform.Rotate((-1) * Vector3.one * rotateSpeed * Time.deltaTime);
        }
    }
}
