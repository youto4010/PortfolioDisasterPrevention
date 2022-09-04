using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] Slot[] slots = default;
    [SerializeField] Slot selectedSlot = null;

    public static ItemBox instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            // slotsにslot要素をコードを入れる方法
            slots = GetComponentsInChildren<Slot>();
        }
    }
    
    public void SetItem(Item item)
    {
        foreach(Slot slot in slots)
        {
            if(slot.IsEmpty())
            {
                slot.SetItem(item);
                break;
            }
        }
    }

    public void OnSelectSlot(int position)
    {
        // いったんすべてのスロットの選択パネルを表示する
        foreach(Slot slot in slots)
        {
            slot.HideBgPanel();
        }
        selectedSlot = null;

        if(slots[position].OnSelected())
        {
            selectedSlot = slots[position];
        }
    }

    public bool TryUseItem(Item.Type type)
    {
        // 選択アイテムスロットがあるかどうか
        if(selectedSlot == null)
        {
            return false;
        }
        if(selectedSlot.GetItem().type == type)
        {
            selectedSlot.SetItem(null);
            selectedSlot.HideBgPanel();
            selectedSlot = null;
            return true;
        }
        return false;
    }

    public Item GetSelectedItem()
    {
        if(selectedSlot == null)
        {
            return null;
        }
        return selectedSlot.GetItem();
    }
}
