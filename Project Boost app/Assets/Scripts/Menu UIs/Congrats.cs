using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Congrats : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
