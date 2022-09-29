using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    [SerializeField] Animator anim = default;
    // [SerializeField] ColliderCallReceiver aroundColliderCall = null;
    bool shelfFallen = false;
    int damage = 2;
    [SerializeField] int hindranceDamage = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        // aroundColliderCall.TriggerEnterEvent.AddListener( OnTriggerEnter );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag =="Player")
        {
            if(shelfFallen == false)
            {
                anim.Play("WallAnimation");
                shelfFallen = true;
                PlayerController.instance.OnDamage(hindranceDamage);
                Debug.Log("残りHPは"+PlayerController.instance.CurrentStatus.Hp);
            }
        }
    }

    // Start is called before the first frame update
    // protected override void Start()
    // {
    //     base.Start();
    // }

    // protected override void ItemAction(Collider col)
    // {
    //     base.ItemAction(col);
    //     var player = col.gameObject.GetComponent<PlayerController>();
    //     player.OnDamage(hindranceDamage);
    // }
}
