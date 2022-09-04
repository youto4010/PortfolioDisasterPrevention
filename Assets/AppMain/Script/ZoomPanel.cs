using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    // やること
    // Zoomボタンを押されたら、パネルを表示
    // Closeボタンを押されたら、パネルを非表示にする

    public void ShowPanel()
    {
        Item item = ItemBox.instance.GetSelectedItem();
        if (item != null)
        {
            panel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
