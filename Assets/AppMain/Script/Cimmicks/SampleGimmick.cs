using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGimmick : MonoBehaviour
{
    //  アイテムを持っている状態でクリックすると消える。
    // クリック判定
    // アイテムを持ってるか判断する
    [SerializeField] Item.Type clearItem;

    public void OnClickObj()
    {
        Debug.Log("クリックしたよ！");
        // アイテムCubeを持っているかどうか
        bool clear = ItemBox.instance.TryUseItem(clearItem);
        if(clear == true)
        {
            Debug.Log("ギミック解除");
            gameObject.SetActive(false);
        }
    }
}
