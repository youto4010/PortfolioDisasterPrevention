using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    [SerializeField] ColliderCallReceiver aroundColliderCall = null; 
    [SerializeField] float attackInterval = 3f;
    [SerializeField] ColliderCallReceiver attackHitColliderCall = null;
    // 自身のコライダー
    [SerializeField] Collider myCollider = null;
    // 攻撃ヒット時エフェクトプレハブ
    [SerializeField] GameObject hitParticlePrefab =null;
    bool isBattle=false;
    float attackTimer=0f;
    // Start is called before the first frame update
    void Start()
    {
        // 現在のステータスを基本ステータスとする
        CurrentStatus.Hp = DefaultStatus.Hp;
        CurrentStatus.Power = DefaultStatus.Power;
        // 周辺コライダーイベント登録
        aroundColliderCall.TriggerEnterEvent.AddListener(OnAroundTriggerEnter);
        aroundColliderCall.TriggerStayEvent.AddListener(OnAroundTriggerStay);
        aroundColliderCall.TriggerExitEvent.AddListener(OnAroundTriggerExit);
        // 攻撃コライダーイベント登録
        attackHitColliderCall.TriggerEnterEvent.AddListener(OnAttackTriggerEnter);
        attackHitColliderCall.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 攻撃できる状態の時
        if(isBattle == true)
        {
            attackTimer += Time.deltaTime;

            if(attackTimer >=3f)
            {
                attackTimer=0;
            }
        }
        else
        {
            attackTimer=0;
        }
    }
    public void OnAttackHit(int damage,Vector3 attackPosition)
    {
        CurrentStatus.Hp -= damage;
        Debug.Log("Hit Damage"+ damage + "/CurrentHp =" + CurrentStatus.Hp);
        var pos = myCollider.ClosestPoint(attackPosition);
        var obj = Instantiate(hitParticlePrefab,pos,Quaternion.identity);
        var par = obj.GetComponent<ParticleSystem>();
        StartCoroutine(WaitDestroy(par));


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
    void OnAroundTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
        }
    }
    void OnAroundTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            isBattle=true;
        }
    }
    void OnAroundTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isBattle = false;
        }
    }
    void OnAttackTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            Debug.Log("Playerは" + CurrentStatus.Power +"ダメージ受けた");
            var player = other.GetComponent<PlayerController>();
            player?.OnEnemyAttackHit(CurrentStatus.Power,this.transform.position);
            attackHitColliderCall.gameObject.SetActive(false);
        }
    }
    IEnumerator WaitDestroy(ParticleSystem particle)
    {
        yield return new WaitUntil(()=>particle.isPlaying == false);
        Destroy(particle.gameObject);
    }

}
