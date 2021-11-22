using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RocketMove : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    public ParticleSystem[] visual;
    public new AudioClip[] audio;
    public Text fuel;

    [SerializeField] private float thrustSpeed = 200.0f;
    [SerializeField] private float rotateSpeed = 200.0f;
    [SerializeField] private float changeThrust = 1130f;
    [SerializeField] private float fuelNum = 30;

    enum State {Alive, Dead, Won};
    State state = State.Alive;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.freezeRotation = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        fuel.text = "Fuel: " + fuelNum.ToString();
        Debug.Log(Mathf.Round(Mathf.Sin(Mathf.PI)));
        Debug.Log((Mathf.Sin(Mathf.Epsilon)).ToString());
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

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audio[2]);
            }

            Fuelling();
        }
        else
        {
            thrustSpeed = changeThrust;
            visual[0].Stop();
            audioSource.Stop();
        }
    }

    private void Fuelling()
    {
        int temp;
        if(fuelNum <= Mathf.Epsilon)
        {
            audioSource.Stop();
            Dead();
        }
        temp = (int)fuelNum;
        fuel.text = "Fuel: " + temp.ToString();
        fuelNum -= Time.deltaTime; 
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
                audioSource.Stop();
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

        rb.freezeRotation = true;


        if (!visual[2].isPlaying)
        {
            visual[2].Play();
            visual[0].Stop();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audio[1]);
        }

        Invoke("LoadNextScene", 4.0f);

       
    }

    private void Dead()
    {
        state = State.Dead;

        rb.freezeRotation = true;


        if (!visual[1].isPlaying)
        {
            visual[1].Play();
            visual[0].Stop();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audio[0]);
        }

        Invoke("LoadSameScene", 4.0f);
    }

    private void LoadNextScene()
    {
        if(SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1))
        {
            SceneManager.LoadScene(0);       
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void LoadSameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
