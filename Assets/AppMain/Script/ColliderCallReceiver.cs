using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderCallReceiver : MonoBehaviour
{ 
    //トリガーイベント定義クラス
    public class TriggerEvent : UnityEvent<Collider>{}
    //トリガーエンターイベント
    public TriggerEvent TriggerEnterEvent = new TriggerEvent();
    //トリガーステイイベント
    public TriggerEvent TriggerStayEvent = new TriggerEvent();
    //トリガーイグジットイベント
    public TriggerEvent TriggerExitEvent = new TriggerEvent();
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        TriggerEnterEvent?.Invoke(other);
    }
    void OnTriggerStay(Collider other)
    {
        TriggerStayEvent?.Invoke(other);
    }
    void OnTriggerExit(Collider other)
    {
        TriggerExitEvent?.Invoke(other);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
