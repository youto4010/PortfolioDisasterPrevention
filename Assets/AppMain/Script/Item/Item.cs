using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item 
{
    // 列挙型、種類を定義する
    public enum Type
    {
        Cube,
        Ball,
        Bar,
        Rope,
        Tanker,
        Water,
    }

    public Type type;
    public Sprite sprite;
    public GameObject zoomObj;

    public Item(Type type,Sprite sprite,GameObject zoomObj)
    {
        this.type = type;
        this.sprite = sprite;
        this.zoomObj = zoomObj;
    }

}
