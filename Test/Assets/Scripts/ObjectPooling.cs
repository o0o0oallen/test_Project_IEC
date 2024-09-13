using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;    
    List<GameObject> spawnedObject = new List<GameObject>();
    public List<GameObject> Prefabs = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public GameObject SpawnObject(string objectName,Vector2 SpawnPos)
    {
        Debug.Log(objectName);
        bool isSpawned = false;
        foreach (GameObject obj in spawnedObject)
        {
            if (obj.name == objectName+"(Clone)"&&!obj.activeInHierarchy)
            {
                isSpawned = true;
                obj.transform.position = SpawnPos;
                obj.SetActive(true);
                return obj;
            }
        }

        if (!isSpawned) 
        {
            foreach (GameObject obj in Prefabs)
            {
                Debug.Log("spawn") ;
                if (obj.name == objectName) 
                {

                    GameObject spawnObject = Instantiate(obj,SpawnPos,Quaternion.Euler(0,0,0),transform);
                    spawnedObject.Add(spawnObject);
                    return spawnObject;
                }
            }
        }
        return null;
    }
    public GameObject SpawnObject(string objectName)
    {
        Debug.Log(objectName);

        bool isSpawned = false;
        foreach (GameObject obj in spawnedObject)
        {
            if (obj!=null&&obj.name == objectName&&!obj.activeInHierarchy)
            {
                isSpawned = true;
                /*obj.transform.position = SpawnPos;*/
                obj.SetActive(true);
                return obj;
            }
        }
        if (!isSpawned) 
        {
            foreach (GameObject obj in Prefabs)
            {
                if (obj.name == objectName) 
                {
                    GameObject spawnObject = Instantiate(obj);
                    spawnedObject.Add(spawnObject);
                    return spawnObject;
                }
            }
        }
        return null;
    }
    public void Clear()
    {
        spawnedObject.Clear();
        foreach (GameObject obj in spawnedObject)
            Destroy(obj);
    }
}
