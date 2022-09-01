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
    }

    public Type type;
    public Sprite sprite;

    public Item(Type type,Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }

}
