using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RocketMove : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ThrustRocket();
        RotateRocket();
    }



    private void ThrustRocket()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * 8);
            Debug.Log("Up");
        }
    }

    private void RotateRocket()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate((-1) * Vector3.one * 5);
            Debug.Log("Left");
        }
    }
}
