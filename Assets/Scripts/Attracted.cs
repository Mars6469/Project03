using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attracted : MonoBehaviour
{
    public GameObject atrractedTo;
    public float strengthOfAttraction = 1.0f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = atrractedTo.transform.position - transform.position;
        rb.AddForce(strengthOfAttraction * direction);
    }
}
