using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObj : MonoBehaviour
{
    [SerializeField] GameObject setObjectAppear;
    [SerializeField] GameObject setObjectDisappear;
    [SerializeField] Item.Type userItem;
    // 適切なアイテムを選択した状態で
    // このオブジェクトをクリックしたら
    public void OnClickAppear()
    {
        // 適切なアイテムを選択した状態で
        bool hasItem = ItemBox.instance.TryUseItem(userItem);
        if(hasItem)
        {
            // アイテムを表示する
            setObjectAppear.SetActive(true);
        }
    }
    public void OnClickDisappear()
    {
        // 適切なアイテムを選択した状態で
        bool hasItem = ItemBox.instance.TryUseItem(userItem);
        if(hasItem)
        {
            // アイテムを表示する
            setObjectDisappear.SetActive(false);
        }
    }
}
