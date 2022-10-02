using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance_Bullet : MonoBehaviour
{
    public float timeOut = 1.0f;
    private float timeElapsed;
    public GameObject cube;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= timeOut)
        {
            Instantiate(cube,Player.transform.position,Quaternion.identity);
            timeElapsed = 0.0f;
        }
    }
}
