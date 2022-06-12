using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    [System.Serializable]
    public class Status
    {
        //HP 
        public int Hp =10;
        //  攻撃力
        public int Power =1;
    }
    // 基本ステータス
    [SerializeField]
    Status DefaultStatus = new Status();
    // 現在のステータス
    public Status CurrentStatus = new Status();
    // Start is called before the first frame update
    void Start()
    {
        // 現在のステータスを基本ステータスとする
        CurrentStatus.Hp = DefaultStatus.Hp;
        CurrentStatus.Power = DefaultStatus.Power;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnAttackHit(int damage)
    {
        CurrentStatus.Hp -= damage;
        Debug.Log("Hit Damage"+ damage + "/CurrentHp =" + CurrentStatus.Hp);

        if(CurrentStatus.Hp <0)
        {
            OnDie();
        }
    }
    void OnDie()
    {
        Debug.Log("鎮火");
        this.gameObject.SetActive(false);
    }

}
