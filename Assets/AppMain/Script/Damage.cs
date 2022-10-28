using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int hindranceDamage = 2;
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag =="Player")
        {
                PlayerController.instance.OnDamage(hindranceDamage);
                Debug.Log("残りHPは"+PlayerController.instance.CurrentStatus.Hp);
        }
    }
}
