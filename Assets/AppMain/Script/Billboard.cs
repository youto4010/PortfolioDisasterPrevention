using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // ターゲットカメラ
    [SerializeField]Camera lookCamera = null;
    [SerializeField]bool isY =false;
    // Start is called before the first frame update
    void Start()
    {
        if(lookCamera == null)lookCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(lookCamera =null)return;
        // Y軸回転のみ
        if(isY == true)
        {
            var cameraPos = lookCamera.transform.position;
            cameraPos.y = this.transform.position.y;
            var look = this.transform.position - cameraPos;

            this.transform.forward = look;
        }
        // 完全に正面にカメラを向ける
        else
        {
            var cameraPos = lookCamera.transform.position;
            var look = this.transform.position - cameraPos;

            this.transform.forward = look;
        }
    }
}
