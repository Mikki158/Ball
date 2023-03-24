using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YelowPlatform : MonoBehaviour
{
    public GameObject pointPlatform;
    public Material standartMaterial;
    public Material yelowMaterial;


    private void OnCollisionEnter(Collision collision)
    {
        pointPlatform.GetComponent<Renderer>().material = standartMaterial;
        PlayerPrefs.SetInt("Point", PlayerPrefs.GetInt("Point") + 1);
        Debug.Log(PlayerPrefs.GetInt("Point"));
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void RemovePoint()
    {
        pointPlatform.GetComponent<Renderer>().material = yelowMaterial;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
