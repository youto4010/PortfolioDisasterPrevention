using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject slotPrefab;

    private int slotNumber = 9;

    [SerializeField]
    private Item[] allItems;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < slotNumber; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab,this.transform);

            Slot slot = slotObj.GetComponent<Slot>();

            if (i<allItems.Length)
            {
                slot.SetItem(allItems[i]);
            }
            else
            {
                slot.SetItem(null);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
