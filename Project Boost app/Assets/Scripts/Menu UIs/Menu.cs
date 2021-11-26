using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button continuous;

    private int levelLoad = 0;
    private void Start()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            levelLoad = PlayerPrefs.GetInt("level");
            Debug.Log(levelLoad);
            continuous.gameObject.SetActive(true);
        }
        else if (PlayerPrefs.HasKey("level") || levelLoad == SceneManager.sceneCount - 1) 
        {
            continuous.gameObject.SetActive(false);
        }
        //PlayerPrefs.DeleteKey("level");
    }
    public void ToGame()
    {
        SceneManager.LoadScene("About");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Story()
    {
        SceneManager.LoadScene("Story");
    }

    public void Continue()
    {
        if(levelLoad != 0)
        {
            SceneManager.LoadScene(levelLoad);
        }
    }
}
