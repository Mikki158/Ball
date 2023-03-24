using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlatform : MonoBehaviour
{
    public int needPoint;
    public bool start;
    public bool point;
    public Transform teleport;

    public GameObject Panel;
    public GameObject trigerPanel;

    public Material green;
    public Material blackGreen;

    private void Update()
    {
        if (point == true)
        {
            if (PlayerPrefs.GetInt("Point") != needPoint)
            {
                Panel.GetComponent<Renderer>().material = blackGreen;
                trigerPanel.GetComponent<BoxCollider>().enabled = false;
            }
            if (PlayerPrefs.GetInt("Point") >= needPoint)
            {
                Panel.GetComponent<Renderer>().material = green;
                trigerPanel.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (start == false)
        {
            Rigidbody _rigidbody = collision.gameObject.GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
            collision.gameObject.GetComponent<PlayerController>().RemovePoint();
            PlayerPrefs.SetInt("Point", 0);
            collision.gameObject.transform.position = new Vector3(teleport.position.x, teleport.position.y + 0.37f, teleport.position.z);
            transform.rotation = new Quaternion(180f, 270f, 0f, 0f);
            _rigidbody.isKinematic = false;

            PlayerPrefs.SetInt("Levl", PlayerPrefs.GetInt("Levl") + 1);
            //collision.gameObject.GetComponent<PlayerController>().gameMeneger.GetComponent<GameMeneger>().textLevela.text = "Уровень: " + PlayerPrefs.GetInt("Levl");
            Debug.Log(PlayerPrefs.GetInt("Levl"));
            
        }
        if (start == true)
        {            
            PlayerPrefs.SetFloat("xSpawn", transform.position.x);
            PlayerPrefs.SetFloat("ySpawn", transform.position.y);
            PlayerPrefs.SetFloat("zSpawn", transform.position.z);            
        }
    }
}
