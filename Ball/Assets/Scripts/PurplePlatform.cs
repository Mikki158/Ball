using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PurplePlatform : MonoBehaviour
{
    public Vector3[] goPosition = new Vector3[4];
    public float speed;
    public int position;

    private float _progress;
    

    private void FixedUpdate()
    {
        if (position <= 2)
        {
            transform.position = Vector3.Lerp(goPosition[position], goPosition[position + 1], _progress);

            if (transform.position == goPosition[position + 1])
            {
                position += 1;
                _progress = 0;
            }
        }
        else if (position == 3)
        {
            transform.position = Vector3.Lerp(goPosition[position], goPosition[0], _progress);    
            
            if (transform.position == goPosition[0])
            {
                position = 0;
                _progress = 0;
            }
        }

        _progress += speed;

        
    }
}
