using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatform : MonoBehaviour
{
    public float time = 0.6f;

    private bool gravity = false;
    private Vector3 start;

    private void Start()
    {
        start = transform.position;
    }

    private void FixedUpdate()
    {
        if (gravity == true)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.drag = 6;
            rb.isKinematic = false;
        }
        if (time < -3)
        {
            transform.position = start;
            time = 0.6f;
            gravity = false;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gravity = true;
        }
    }

    private void Timer()
    {
        time = time - Time.deltaTime;
        if (time <= 0)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.drag = 6;
            rb.isKinematic = false;
        }
    }
}
