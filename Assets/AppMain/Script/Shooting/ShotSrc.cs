using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShotSrc : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float bulletPower = 500f;
    [SerializeField] Slider FireBar= null;
    private int WaterPoint = 1;
    [System.Serializable]
    public class Status
    {
        // 体力
        public int Hp = 15;
    }
    // 基本ステータス
    [SerializeField] Status DefaultStatus = new Status();
    // 現在のステータス
    public Status CurrentStatus = new Status();
    // Start is called before the first frame update
    void Start()
    {
        // スライダーの初期設定
        FireBar.maxValue = DefaultStatus.Hp;
        FireBar.value = CurrentStatus.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            var bulletInstance = Instantiate<GameObject>(bulletPrefab,muzzle.position,muzzle.rotation*Quaternion.Euler(0, 0, 0));
            Debug.Log(muzzle.position);
            Debug.Log(muzzle.rotation.GetType());
            bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.up*bulletPower);
            CurrentStatus.Hp -= WaterPoint;
            // transform.position = Vector3.MoveTowards(transform.position,direction,step);
            Destroy(bulletInstance,5f);
        }

        if(CurrentStatus.Hp == 0)
        {
            
        }
    }


}
