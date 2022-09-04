using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Item item = default;
    [SerializeField]Image image = default;
    [SerializeField]GameObject backgroundPanel = default;

    private void Awake()
    {
        // image = GetComponent<Image>();
    }

    private void Start()
    {
        backgroundPanel.SetActive(false);
    }

    public bool IsEmpty()
    {
        if(item == null)
        {
            return true;
        }
        return false;
    }

    public void SetItem(Item item)
    {
        this.item = item;
        UpdateImage(item);
    }

    public Item GetItem()
    {
        return item;
    }

    void UpdateImage(Item item)
    {
        if(item == null)
        {
            image.sprite = null;
        }
        else
        {
            image.sprite = item.sprite;
        }
    }

    public bool OnSelected()
    {
        if(item==null)
        {
            return false;
        }
        backgroundPanel.SetActive(true);
        return true;
    }

    public void HideBgPanel()
    {
        backgroundPanel.SetActive(false);
    }
}
