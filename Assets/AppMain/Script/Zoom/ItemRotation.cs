using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    [SerializeField] Transform parent;
    float k= 500f;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float x = -Input.GetAxis("Mouse X") * Time.deltaTime * k;
            float y = -Input.GetAxis("Mouse Y") * Time.deltaTime * k;
            transform.RotateAround(transform.position,Quaternion.Euler(parent.rotation.eulerAngles) * Vector3.up,x);
            transform.RotateAround(transform.position,Quaternion.Euler(parent.rotation.eulerAngles) * Vector3.right,y);
        }
    }
}
