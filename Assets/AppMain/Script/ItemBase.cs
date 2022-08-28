using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ColliderCallReceiver))]

public class ItemBase : MonoBehaviour
{
    [Header("Base Param")]
    // 取得時のエフェクトプレハブ
    [SerializeField] GameObject effectParticle = null;
    // アイテムのレンダラー
    [SerializeField] Renderer itemRenderer = null;

    // コライダーコール
    ColliderCallReceiver ColliderCall = null;
    // エフェクト実行フラグ
    bool isEffective = true;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        ColliderCall = GetComponent<ColliderCallReceiver>();
        ColliderCall.TriggerEnterEvent.AddListener(OnTriggerEnter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(isEffective == false) return;

        if(col.gameObject.tag == "Player")
        {
            Debug.Log("アイテムを取得");
            // オーバーライド可能な処理を実行
            ItemAction(col);
            isEffective = false;

            // エフェクト表示
            if(effectParticle != null)
            {
                var pos = (itemRenderer == null)? this.transform.position : itemRenderer.gameObject.transform.position;
                var obj = Instantiate(effectParticle,pos,Quaternion.identity);
                var particle = obj.GetComponent<ParticleSystem>();
                StartCoroutine(AutoDestroy(particle));
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator AutoDestroy(ParticleSystem particle)
    {
        // 先にレンダラーを消す
        if(itemRenderer != null) itemRenderer.enabled = false;
        yield return new WaitUntil(()=>particle.isPlaying == false);

        // 破棄
        Destroy(gameObject);
    }

    protected virtual void ItemAction(Collider col)
    {

    }
}
