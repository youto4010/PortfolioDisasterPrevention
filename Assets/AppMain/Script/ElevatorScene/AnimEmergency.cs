using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimEmergency : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Animator animator = default;
    [SerializeField] GameObject emergencyBox = default;
    public void OnClick(){
        animator.Play("openAnim");
        StartCoroutine("SceneChange");
        Debug.Log("クリックしました");
    }

    IEnumerator SceneChange(){
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("ConversationScene3");
    }
}
