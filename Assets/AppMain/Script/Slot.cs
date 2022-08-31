using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IBeginDragHandler,IDragHandler,IDropHandler,IEndDragHandler
{
    private Item item;
    [SerializeField]
    private Image itemImage;

    private GameObject draggingObj;
    [SerializeField]
    private GameObject itemImageObj;
    private Transform canvasTransform;
    private Hand hand;

    public Item MyItem {get => item; private set=> item = value;}
    
    private void Start()
    {
        canvasTransform = FindObjectOfType<Canvas>().transform;
        hand = FindObjectOfType<Hand>();
    }

    public void SetItem(Item item)
    {
        MyItem = item;

        if(item!=null)
        {
            itemImage.color = new Color(1,1,1,1);
            itemImage.sprite = item.MyItemImage;
        }
        else
        {
            itemImage.color = new Color(0,0,0,0);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(MyItem == null) return;
        Debug.Log("ドラッグ開始");
        draggingObj = Instantiate(itemImageObj,canvasTransform);
        draggingObj.transform.SetAsLastSibling();
        itemImage.color=Color.gray;
        hand.SetGrabbingItem(MyItem);
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(MyItem == null) return;
        Debug.Log("ドラッグ中");
        draggingObj.transform.position = hand.transform.position + new Vector3(20,20,0);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(!hand.IsHavingItem()) return;
        Item gotItem = hand.GetGrabbingItem();
        hand.SetGrabbingItem(MyItem);
        SetItem(gotItem);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(draggingObj);

        Item gotItem = hand.GetGrabbingItem();
        SetItem(gotItem);
    }
}
