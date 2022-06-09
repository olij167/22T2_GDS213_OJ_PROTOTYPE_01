using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StallObjectRandomiser : MonoBehaviour
{
    public List<GameObject> stallObjectList;

    void Start()
    {
        SpawnObject();
    }

    void Update()
    {
        
    }

    void SpawnObject()
    {
        Instantiate(stallObjectList[Random.Range(0, stallObjectList.Count)], gameObject.transform.position, Quaternion.identity);
    }
}
