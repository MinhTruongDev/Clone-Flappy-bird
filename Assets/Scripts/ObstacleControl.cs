using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    [SerializeField] public GameObject prefab;         
    float spawnTimer = 1f;
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            // Spawn obstacle
            GameObject newPipe = Instantiate(prefab);
            newPipe.transform.position = transform.position + new Vector3(0, UnityEngine.Random.Range(12f, -12f), 0);    
            
            //Destroy after 5s
            Destroy(newPipe, 5f);
            //reset timer
            spawnTimer = 1f;
        }
        
    }

   
}
