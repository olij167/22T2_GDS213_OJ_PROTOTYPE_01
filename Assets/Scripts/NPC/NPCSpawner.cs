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

            Color randomColour;
            int coinFlip;

            if (spawnedNPCs[i].name.Contains("Child"))
            {
                coinFlip = Random.Range(0, 2);

                if (coinFlip == 0)
                {
                    randomColour = Random.ColorHSV(0f, 0.2f, 0.75f, 0.95f, 0.85f, 1f);
                }
                else
                {
                    randomColour = Random.ColorHSV(0.5f, 1f, 0.75f, 0.95f, 0.85f, 1f);

                }
            }
            
            else if (spawnedNPCs[i].name.Contains("Adult"))
            {
                coinFlip = Random.Range(0, 2);

                if (coinFlip == 0)
                {
                    randomColour = Random.ColorHSV(0f, 0.2f, 0.45f, 0.7f, 0.75f, 1f);
                }
                else
                {
                    randomColour = Random.ColorHSV(0.5f, 1f, 0.45f, 0.7f, 0.75f, 1f);

                }
            }
            
            else if (spawnedNPCs[i].name.Contains("Elderly"))
            {

                coinFlip = Random.Range(0, 2);

                if (coinFlip == 0)
                {
                    randomColour = Random.ColorHSV(0f, 0.2f, 0.1f, 0.4f, 0.65f, 1f);
                }
                else
                {
                    randomColour = Random.ColorHSV(0.5f, 1f, 0.1f, 0.4f, 0.65f, 1f);

                }
            }
            else
            {
                coinFlip = Random.Range(0, 2);

                if (coinFlip == 0)
                {
                    randomColour = Random.ColorHSV(0f, 0.2f, 0.25f, 0.75f, 0.85f, 1f);
                }
                else
                {
                    randomColour = Random.ColorHSV(0.5f, 1f, 0.25f, 0.75f, 0.85f, 1f);

                }
            }

            spawnedNPCs[i].transform.Find("NPC Body").GetComponent<MeshRenderer>().material.color = randomColour;
            spawnedNPCs[i].transform.Find("NPC Head").GetComponent<MeshRenderer>().material.color = randomColour;
            
            //spawnedNPCs[i].GetComponent<Material>().color = Random.ColorHSV(0f, 1f, 0.75f, 1f, 0.75f, 1f);
        }
    }
}
