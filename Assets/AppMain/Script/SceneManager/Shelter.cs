using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shelter : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag =="Player")
        {
            SceneManager.LoadScene("ConversationScene6");
            Debug.Log("避難所に到着しました");
        }
    }
}
