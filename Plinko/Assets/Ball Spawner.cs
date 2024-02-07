using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnRate = 0.1f; 

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextSpawnTime)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.x = 0f; 

            Instantiate(prefabToSpawn, mousePosition, Quaternion.identity);

            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
