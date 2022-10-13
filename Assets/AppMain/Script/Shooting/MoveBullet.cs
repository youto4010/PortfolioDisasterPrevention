using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public GameObject target;
    Vector3 direction;
    float speed = 10.0f;
    float step = 300f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     float step = speed*Time.deltaTime;
    //     transform.position = Vector3.MoveTowards(transform.position,direction,step);
    // }

    public void OnBulletButtonClicked()
    {
        
    }
}
