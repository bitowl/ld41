using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{

    public List<GameObject> prefabsToSpawn;

    // Use this for initialization
    void Start()
    {
		SpawnPrefabs();
    }

    public void SpawnPrefabs()
    {
        foreach (GameObject prefab in prefabsToSpawn)
        {
			GameObject instantiated = Instantiate(prefab);
			instantiated.transform.parent = transform.parent;
            
        }
    }

}
