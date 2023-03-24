using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlatform : MonoBehaviour
{    
    public Vector3 endPosition;
    public float speed;

    public Vector3 _startPosition;
    public float _progress;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(_startPosition, endPosition, _progress);
        _progress += speed;
        if (transform.position == endPosition)
        {
            Vector3 temp = _startPosition;
            _startPosition = endPosition;
            endPosition = temp;
            _progress = 0;
            //speed *= -1;
        }
        //else if (transform.position == _startPosition)
        //{
        //    Vector3 temp = _startPosition;
        //    _startPosition = endPosition;
        //    endPosition = _startPosition;
        //}

    }

}
