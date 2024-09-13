using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
[CreateAssetMenu(fileName = "Data", menuName = "SkinData")]
public class SkinData : ScriptableObject
{  
    public List<GameObject> itemPrefabs = new List<GameObject>();
    public int currentSkinId=0;
    [Serializable]
    public struct skinList
    {
        public List<Sprite> listSkin;
        public Sprite getSprite(int index)
        {
            return listSkin[index];
        }
    }

    public List<skinList> listFolder = new List<skinList>();
    public void setSkin()
    {
        if(currentSkinId<0||currentSkinId>=listFolder.Count)
            currentSkinId = 0;
        for (int i = 0; i < itemPrefabs.Count; i++)
        {
            itemPrefabs[i].GetComponent<SpriteRenderer>().sprite = listFolder[currentSkinId].getSprite(i);
        }
    }
    
}
