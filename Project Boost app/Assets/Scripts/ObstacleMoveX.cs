using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ObstacleMoveX : MonoBehaviour
{
    [SerializeField] Vector3 initial;
    [SerializeField] private float temp = 3.0f;
    private float factor;
    // Start is called before the first frame update
    void Start()
    {
        initial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        factor = Mathf.Sin((2 * Mathf.PI / 2) * Time.time);
        transform.position = new Vector3(initial.x + temp * factor, initial.y, initial.z);
    }
}
