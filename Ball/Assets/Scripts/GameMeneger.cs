using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMeneger : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject mainCamera;
    public TextMeshProUGUI textLevela;

    float xSpawn;
    float ySpawn;
    float zSpawn;

    private void Awake()
    {
        xSpawn = 0f;
        ySpawn = 1f;
        zSpawn = -3f;
        Spawn();
    }

    public void Spawn()
    {
        //float xSpawn = PlayerPrefs.GetFloat("xSpawn");
        //float ySpawn = PlayerPrefs.GetFloat("ySpawn");
        //float zSpawn = PlayerPrefs.GetFloat("zSpawn");
        GameObject player = Instantiate(playerPrefab);
        player.transform.position = new Vector3(xSpawn, ySpawn + 0.37f, zSpawn);
        mainCamera.GetComponent<ToFollow>().objToFollow = player.transform;
        mainCamera.GetComponent<Transform>().position = new Vector3(xSpawn + 1.408f, ySpawn + 0.37f + 1.708f, zSpawn - 1.528f);
        mainCamera.GetComponent<Transform>().Rotate(35.8f, -42.73f, 0f);
    }

    public void Spawn(GameObject destroyPlayer)
    {
        
        float xSpawn = PlayerPrefs.GetFloat("xSpawn");
        float ySpawn = PlayerPrefs.GetFloat("ySpawn");
        float zSpawn = PlayerPrefs.GetFloat("zSpawn");
        GameObject player = Instantiate(playerPrefab);
        //Destroy(destroyPlayer);
        player.transform.position = new Vector3(xSpawn, ySpawn + 0.37f, zSpawn);
        mainCamera.GetComponent<ToFollow>().objToFollow = player.transform;
        mainCamera.GetComponent<Transform>().position = new Vector3(xSpawn + 1.408f, ySpawn + 0.37f + 1.708f, zSpawn - 1.528f);
        mainCamera.GetComponent<Transform>().Rotate(35.8f, -42.73f, 0f);
    }
}
