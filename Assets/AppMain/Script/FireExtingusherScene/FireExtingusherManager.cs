using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FireExtingusherManager : MonoBehaviour
{
    [SerializeField] Animator anim = default;
    [SerializeField] Text navText = default;
    [SerializeField] GameObject FireExtingusherBefore = default;
    [SerializeField] GameObject FireExtingusherAfter = default;
    float phaseManage = 0;
    // Start is called before the first frame update
    void Start()
    {
        navText.text = "ピンを抜いてください";
    }

    public void OnClickPin(){
        anim.Play("FireExtingusherTrigger");
        navText.text = "ホースを持ってください";
        phaseManage++;
        Debug.Log(phaseManage);
    }

    public void OnClickHose(){
        if(phaseManage == 1){
            navText.text = "レバーを握って放水してください";
            FireExtingusherBefore.SetActive(false);
            FireExtingusherAfter.SetActive(true);
            phaseManage++;
        }
    }

    public void OnClickLever(){
        if(phaseManage == 2){
            SceneManager.LoadScene("ShootingScene");
        }
    }
}
