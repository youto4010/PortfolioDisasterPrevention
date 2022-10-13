using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    [SerializeField] GameObject emergencyButton = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickEmergencyButton()
    {
        SceneManager.LoadScene("ConversationScene2");
        // emergencyButton.SetActive(false);
        // Debug.Log("押した");
    }
}
