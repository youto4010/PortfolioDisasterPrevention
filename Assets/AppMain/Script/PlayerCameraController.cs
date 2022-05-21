using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    // 回転操作用トランスフォーム
    [SerializeField]Transform rotationRoot=null;
    // 高さ操作用トランスフォーム
    [SerializeField]Transform heightRoot=null;
    // プレイヤーカメラ
    [SerializeField]Camera mainCamera=null;
    [SerializeField] float lookHeight=1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCameraLook(Transform player)
    {
        // カメラをキャラの少し上に固定
        var cameraMarker = player.position;
        cameraMarker.y +=lookHeight;
        var _camlook=(cameraMarker - mainCamera.transform.position).normalized;
        mainCamera.transform.forward=_camlook;
    }
}
