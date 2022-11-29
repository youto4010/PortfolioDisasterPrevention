using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTent : MonoBehaviour
{
    [SerializeField] GameObject setObjectAppear;
    [SerializeField] GameObject setObjectDisappear;
    [SerializeField] Item.Type userItem;
    // 適切なアイテムを選択した状態で
    // このオブジェクトをクリックしたら
    public void OnClick()
    {
        // 適切なアイテムを選択した状態で
        bool hasItem = ItemBox.instance.TryUseItem(userItem);
        if(hasItem)
        {
            // アイテムを表示する
            setObjectAppear.SetActive(true);
            setObjectDisappear.SetActive(false);
        }
    }
}

