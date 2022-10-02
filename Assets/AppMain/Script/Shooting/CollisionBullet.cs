using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour
{
    int fireHp = 30;
    int bulletPower = 2;

    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        fireHp -= bulletPower;
        if(fireHp == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("鎮火");
        }
    }
}
