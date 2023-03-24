using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform spawn;
    public GameObject gameMeneger;
    public TextMeshProUGUI textLevls;
    public AudioSource die;

    private Rigidbody _rigidbody;
    private List<GameObject> listPoint = new List<GameObject>();

    private void Start()
    {
        //PlayerPrefs.SetInt("Levl", 0);
        //textLevls.text = "Уровень: " + PlayerPrefs.GetInt("Levl");
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(-v+h, 0, h+v);
        _rigidbody.AddForce(directionVector.normalized * speed);

        if (transform.position.y < -3)
        {
            die.Play();
            _rigidbody.isKinematic = true;
            float xSpawn = PlayerPrefs.GetFloat("xSpawn");
            float ySpawn = PlayerPrefs.GetFloat("ySpawn");
            float zSpawn = PlayerPrefs.GetFloat("zSpawn");
            RemovePoint();
            PlayerPrefs.SetInt("Point", 0);
            transform.position = new Vector3(xSpawn, ySpawn + 0.37f, zSpawn);
            transform.rotation = new Quaternion(180f, 270f, 0f, 0f);
            _rigidbody.isKinematic = false;
        }

        //textLevls.text = "Уровень: " + PlayerPrefs.GetInt("Levl");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            listPoint.Add(collision.gameObject);
            Debug.Log("Da");
        }
    }


    public void RemovePoint()
    {
        foreach (GameObject item in listPoint)
        {
            item.GetComponent<YelowPlatform>().RemovePoint();
        }
        listPoint.Clear();
    }
}
