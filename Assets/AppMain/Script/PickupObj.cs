using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{
    [SerializeField] Item.Type itemType;
    Item item;

    private void Start()
    {
        item = ItemGenerater.instance.Spawn(itemType);
    }

    public void OnClickObj()
    {
        Debug.Log(item);
        ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);
    }
}
