using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ObstacleMoveY : MonoBehaviour
{
    [SerializeField] Vector3 initial;
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
        transform.position = new Vector3(initial.x * factor, initial.y * factor, initial.z);
    }
}
