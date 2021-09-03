using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Prefabs;
    private List<GameObject> SpawnedPrefabs = new List<GameObject>();
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject[] Pocetni;
    private int spawned = 3;
    private bool startDeleted = false;
    void Start()
    {
    }

    void Update()
    {
        if (player.position.z >= (spawned - 2) * 50 - 50)
            SpawnPrefab();
    }
    private void SpawnPrefab()
    {
        int n = spawned + 3;
        for (int i = spawned + 1; i <= n; i++)
        {
            SpawnedPrefabs.Add(Instantiate(Prefabs[Random.Range(0, Prefabs.Length - 1)], new Vector3(0, 0, (spawned) * 50), Quaternion.Euler(0, -90, 0)));
            //Destroy(SpawnedPrefabs[i-2]);
            
            //print(SpawnedPrefabs[i].transform.position);
            spawned++;
        }
        DeleteBehind();




    }
    private void DeleteBehind()
    {
        if(spawned >= 9)
        {
            if (!startDeleted)
            {
                if (player.transform.position.z >= SpawnedPrefabs[spawned - 9].transform.position.z)
                {
                    foreach (GameObject o in Pocetni)
                    {
                        Destroy(o);
                        startDeleted = true;
                    }
                }
            }
            else
            {
                if (player.transform.position.z >= SpawnedPrefabs[0].transform.position.z)
                {
                    //print(SpawnedPrefabs[spawned - 12].transform.position.z);
                    for (int i = 0; i < 3; i++)
                    {
                        Destroy(SpawnedPrefabs[i]);
                        
                    }
                    SpawnedPrefabs.RemoveRange(0, 3);
                }
            }
        }
    }
}
