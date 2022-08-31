// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
// public class ItemDataBase : ScriptableObject{
//     [SerializeField] private List<Item> itemLists = new List<Item>();
//     // アイテムリストを返す
//     public List<Item> GetItemLists(){
//         return itemLists;
//     }
// }

// public class ItemManager : MonoBehaviour
// {
//     static ItemManager instance;

//     public static ItemManager GetInstance()
//     {
//         return instance;
//     }

//     void Start()
//     {
//         instance = this;
//     }

//     public bool HasItem(string searchName)
//     {
//         return itemDataBase.GetItemLists().Exists(item => item.GetItemName() == searchName);
//     }
// }