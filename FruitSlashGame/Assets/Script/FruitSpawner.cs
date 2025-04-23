using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruits;
    public float spawnTime = 1f;
    void Start()
    {
        InvokeRepeating("SpawnFruit", 0f, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnFruit()
    {
        int index = Random.Range(0, fruits.Length);
        // Tạo vị trí spawn từ dưới màn hình (trục Y = -6)
        Vector2 spawnPosition = new Vector2(Random.Range(-8f, 8f), -6f);
        Instantiate(fruits[index], spawnPosition, Quaternion.identity);
    }
}
