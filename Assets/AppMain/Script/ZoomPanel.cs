using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Transform objParent;
    GameObject zoomObj;
    // やること
    // Zoomボタンを押されたら、パネルを表示
    // Closeボタンを押されたら、パネルを非表示にする

    public void ShowPanel()
    {
        Item item = ItemBox.instance.GetSelectedItem();
        if (item != null)
        {
            Destroy(zoomObj);
            panel.SetActive(true);
            GameObject zoomObjPrefab = ItemGenerater.instance.GetZoomItem(item.type);
            Instantiate(zoomObjPrefab,objParent);
        }
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        Destroy(zoomObj);
    }
}
