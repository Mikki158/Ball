using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFollow : MonoBehaviour
{
    public Transform objToFollow;

    private Vector3 _deltaPos;

    private void Start()
    {
        _deltaPos = transform.position - objToFollow.position;
    }

    private void Update()
    {
        try
        {
            transform.position = objToFollow.position + _deltaPos;
        }
        catch (MissingReferenceException)
        {

        }
    }
}
