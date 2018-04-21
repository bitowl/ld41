using UnityEditor;
using UnityEngine;
using System;

[CustomEditor(typeof(PrefabSpawner))]
public class PrefabSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        var spawner = target as PrefabSpawner;
        if (GUILayout.Button("Spawn Prefabs"))
        {
            // spawner.SpawnPrefabs();
            foreach (GameObject prefab in spawner.prefabsToSpawn)
            {
                GameObject instantiated = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                instantiated.transform.parent = spawner.transform.parent;
                instantiated.name += "(Clone)";
            }
            spawner.gameObject.SetActive(false);
        }

        if (GUILayout.Button("Delete all cloned objects in scene"))
        {
            spawner.gameObject.SetActive(true);
            Transform parent = spawner.transform.parent;
            if (parent == null)
            {
                GameObject[] gos = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
                Array.Reverse(gos);
                foreach (GameObject go in gos)
                {
                    DeleteGameObject(go);
                }
            }
            else
            {
                for (int i = parent.childCount - 1; i >= 0; i--)
                {
                    GameObject go = parent.GetChild(i).gameObject;
                    // foreach(GameObject go in GameObject.FindObjectsOfType<GameObject>()){
                    DeleteGameObject(go);
                }
            }
        }
    }

    void DeleteGameObject(GameObject go)
    {
        if (go.name != target.name && go.name.EndsWith("(Clone)"))
        {
            DestroyImmediate(go);
        }
    }
}