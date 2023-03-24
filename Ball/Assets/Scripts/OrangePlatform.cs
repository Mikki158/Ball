using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePlatform : MonoBehaviour
{
    public float timeStart;
    public float xRotation;
    public float zRotation;

    private bool start = false;

    private void FixedUpdate()
    {
        if (start == true)
        {
            transform.Rotate(xRotation, 0, zRotation);
        }
        if (start == false)
        {
            timeStart -= Time.deltaTime;
            if (timeStart <= 0)
            {
                start = true;
            }
        }
    }
}
