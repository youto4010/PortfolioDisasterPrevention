using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{ 
    static ItemManager instance;

    public static ItemManager GetInstance();
    [
        return instance;
    ]

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public bool HasItem(string searchName)
    {
        return itemDataBase.GetItemLists().Exists(items => item.GetItemName() = searchName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
