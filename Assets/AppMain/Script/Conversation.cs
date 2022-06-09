using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour

{
    [SerializeField] [Header("メッセージ（キャラ名）")] private string[] msgCharacterName;
    [SerializeField] [Header("メッセージ（内容）")] private string[] msgContent;

    GameObject objCanvas=null;

    // Start is called before the first frame update
    void Start()
    {
        objCanvas= gameObject.transform.Find("Canvas").gameObject;
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
        GameObject objCharacterName = objCanvas.transform.Find("characterName").gameObject;
        GameObject objContent = objCanvas.transform.Find("Content").gameObject;

        objCanvas.SetActive(true);

        for (int i=msgCharacterName.GetLowerBound(0); i<=msgCharacterName.GetUpperBound(0);i++)
        {
            objCharacterName.GetComponent<Text>().text = msgCharacterName[i];
            objContent.GetComponent<Text>().text = msgContent[i];

            yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
            yield return null;
        }
        objCanvas.SetActive(false);
    }
}
