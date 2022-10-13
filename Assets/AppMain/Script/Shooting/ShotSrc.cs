using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSrc : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float bulletPower = 500f;
    // Start is called before the first frame update
    void Start()
    {
        // target = GameObject.Find("Target").gameObject;
        // direction = target.transform.position;
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
            // transform.position = Vector3.MoveTowards(transform.position,direction,step);
            Destroy(bulletInstance,5f);
        }
    }
}
