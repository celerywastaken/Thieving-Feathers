using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpawnManager : MonoBehaviour
{
    private float minSpawnRate = 0.5f;
    private float maxSpawnRate = 2.5f;

    [SerializeField] private GameObject[] npcsPrefabs;

    public bool isGameActive;

    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnNpcs());
    }

    IEnumerator SpawnNpcs()
    {
        // This coroutine runs indefinitely, spawning targets at regular intervals.
        while (isGameActive)
        {
            float randomSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
            // Pause execution for the specified spawnRate duration.
            yield return new WaitForSeconds(randomSpawnRate);

            // Choose a random index from the targets list.
            int index = Random.Range(0, npcsPrefabs.Length);

            // Instantiate the target prefab at the chosen index.
           Vector2 spawnPos = new Vector2(10, -3);
            Instantiate((npcsPrefabs[index]), spawnPos, npcsPrefabs[index].transform.rotation);
        }

    }
}
