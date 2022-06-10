using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationImage : MonoBehaviour
{
    [SerializeField] [Header("画像（左側）")] private sprite[] imgLeftImage;
    [SerializeField] [Header("画像（右側）")] private sprite[] imgRightImage;

    GameObject objCanvas=null;

    // Start is called before the first frame update
    void Start()
    {
        objCanvas= gameObject.transform.Find("Canvas1").gameObject;
        objCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine("ShowLog");
        }
    }
    IEnumerator ShowLog()
    {
        GameObject imgLeftImage = objCanvas.transform.Find("LeftImage").gameObject;
        GameObject imgRightImage = objCanvas.transform.Find("RightImage").gameObject;
        
        objCanvas.SetActive(true);

        for (int i=imgLeftImage.GetLowerBound(0); i<=imgLeftImage.GetUpperBound(0);i++)
        {
            imgLeftImage.GetComponent<Image>().sprite = imgLeftImage[i];
            imgRightImage.GetComponent<Image>().sprite = imgRightImage[i];
            yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
            yield return null;
        }
        objCanvas.SetActive(false);
    }
}