using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public List<Transform> npcPrefabList;

    public int numToSpawn;

    public Transform[] spawnedNPCs;

    void Start()
    {
        spawnedNPCs = new Transform[numToSpawn];

        SpawnNPCS();
    }

    void SpawnNPCS()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            //Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y, transform.position.x + Random.Range(-1f, 1f));
            spawnedNPCs[i] = Instantiate(npcPrefabList[Random.Range(0, npcPrefabList.Count)], transform.position, Quaternion.identity);
        }
    }
}
