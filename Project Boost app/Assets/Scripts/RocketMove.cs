using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RocketMove : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    public ParticleSystem[] visual;
    public new AudioClip[] audio;

    [SerializeField] private float thrustSpeed = 200.0f;
    [SerializeField] private float rotateSpeed = 200.0f;
    [SerializeField] private float changeThrust = 1130f;

    enum State {Alive, Dead, Won};
    State state = State.Alive;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            ThrustRocket();
            RotateRocket();
        }
 
    }

    public void ThrustRocket()
    {
        if (CrossPlatformInputManager.GetButton("Thrust"))
        {
            thrustSpeed += 10;
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
            if (!visual[0].isPlaying)
            {
                visual[0].Play();
            }
        }
        else
        {
            thrustSpeed = changeThrust;
            visual[0].Stop();
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

    private void OnCollisionEnter(Collision collision)
    {
        if(state != State.Alive) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly": Debug.Log("Friendly");
                break;

            case "Finish": 
                FinishLevel();
                break;

            case "Enemy":
                audioSource.Stop();
                Dead();
                break;
        }
    }



    private void FinishLevel()
    {
        state = State.Won;
        if (!visual[2].isPlaying)
        {
            visual[2].Play();
            visual[0].Stop();
        }
    }

    private void Dead()
    {
        state = State.Dead;


        if (!visual[1].isPlaying)
        {
            visual[1].Play();
            visual[0].Stop();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audio[0]);
        }
    }
}
