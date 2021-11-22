using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoText : MonoBehaviour
{
    [SerializeField]private float delay = 0.2f;
    [SerializeField] private string fullTxt;
    private string currentTxt = "";


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullTxt.Length; i++)
        {
            currentTxt = fullTxt.Substring(0, i);
            this.GetComponent<Text>().text = currentTxt;
            yield return new WaitForSeconds(delay);
        }
    }
}
