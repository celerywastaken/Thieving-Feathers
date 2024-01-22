using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpawnManager : MonoBehaviour
{
    private float minSpawnRate = 0.5f;
    private float maxSpawnRate = 2.5f;

    public static SpawnManager instance { get; private set; }

    [SerializeField] private GameObject[] npcsPrefabs;
    private Queue<GameObject> pool = new Queue<GameObject>();

    public bool isGameActive;

    Vector2 spawnPos = new Vector2(10, -3);

    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        isGameActive = true;
        Debug.Log($"{pool.Count}");
        StartCoroutine(SpawnNpcs());
    }

    void Update()
    {
        
    }

    public GameObject GetFromPool()
    {
        if(pool.Count > 0)
        {
            Debug.Log($"Object gotten from Pool, we have {pool.Count} left");
            GameObject dequedObject = pool.Dequeue();
            dequedObject.transform.position = spawnPos;
            dequedObject.SetActive(true);

            dequedObject.transform.GetChild(0).gameObject.SetActive(true);
            return dequedObject;
        }
        else
        {
            return CreateNewNpc(); //todo: create new instance
        }
    }
    public void ReturnBackToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        pool.Enqueue(objectToReturn);
    }

    public GameObject CreateNewNpc()
    {
        int index = UnityEngine.Random.Range(0, npcsPrefabs.Length);
        GameObject objectSpawned = Instantiate((npcsPrefabs[index]), spawnPos, npcsPrefabs[index].transform.rotation);
        return objectSpawned;
    }

    IEnumerator SpawnNpcs()
    {
        // This coroutine runs indefinitely, spawning targets at regular intervals.
        while (isGameActive)
        {
            float randomSpawnRate = UnityEngine.Random.Range(minSpawnRate, maxSpawnRate);
            // Pause execution for the specified spawnRate duration.
            yield return new WaitForSeconds(randomSpawnRate);
            GetFromPool();

            // Choose a random index from the targets list.
                //int index = UnityEngine.Random.Range(0, npcsPrefabs.Length);

            // Instantiate the target prefab at the chosen index.
           
            //((npcsPrefabs[index]), spawnPos, npcsPrefabs[index].transform.rotation);
        }

    }
}
