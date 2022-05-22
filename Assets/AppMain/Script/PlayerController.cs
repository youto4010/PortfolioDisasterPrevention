using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameObject attackHit = null;
    [SerializeField] float jumpPower =50f;
    [SerializeField] ColliderCallReceiver footColliderCall = null;
    [SerializeField] GameObject touchMarker=null;
    [SerializeField] PlayerCameraController cameraController = null;
    Animator animator = null;
    Rigidbody rigid = null;
    bool isAttack = false;
    bool isGround = false;

    
    // PCキー横方向入力
    float horizontalKeyInput = 0;
    // PCキー縦方向入力
    float verticalKeyInput = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
        attackHit.SetActive(false);
        rigid = GetComponent<Rigidbody>();
        footColliderCall.TriggerStayEvent.AddListener(OnFootTriggerStay);
        footColliderCall.TriggerExitEvent.AddListener(OnFootTriggerExit);
    }

    bool isTouch = false;
    // 左半分タッチスタート位置
    Vector2 LeftStartTouch = new Vector2();
    // 左半分タッチ入力
    Vector2 LeftTouchInput = new Vector2();

    // Update is called once per frame
    void Update()
    {
        // カメラをプレイヤーに向ける
        cameraController.UpdateCameraLook(this.transform);
        if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            // スマホタッチ操作
            // タッチしている指の数が0より多い
            if(Input.touchCount > 0)
            {
                isTouch = true;
                // タッチ情報をすべて取得
                Touch[] touches = Input.touches;
                // 全部のタッチを繰り返して判定
                foreach(var touch in touches)
                {
                    bool isLeftTouch=false;
                    bool isRightTouch=false;
                    // タッチ位置のX軸方向がスクリーンの左側
                    if(touch.position.x>0 && touch.position.x<Screen.width/2)
                    {
                        isLeftTouch=true;
                    }
                    // タッチ位置のX軸方向がスクリーンの右側
                    else if(touch.position.x>Screen.width/2 && touch.position.x <Screen.width)
                    {
                        isRightTouch=true;;
                    }
                    // 左タッチ
                    if(isLeftTouch==true)
                    {
                        if(touch.phase == TouchPhase.Began)
                        {
                            Debug.Log("タッチ開始");
                            // 開始位置を保管
                            LeftStartTouch=touch.position;
                            // 開始時にマーカーを表示
                            touchMarker.SetActive(true);
                            Vector3 touchPosition = touch.position;
                            touchPosition.z=1f;
                            Vector3 markerPosition = Camera.main.ScreenToViewportPoint(touchPosition);
                            touchMarker.transform.position = markerPosition;
                            
                        }
                        else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                        {
                            Debug.Log("タッチ中");
                            // 現在地を保管
                            Vector2 position=touch.position;
                            // 移動用の方向を保管
                            LeftTouchInput=position-LeftStartTouch;
                        }
                        else if(touch.phase == TouchPhase.Ended)
                        {
                            Debug.Log("タッチ終了");
                            LeftTouchInput = Vector2.zero;
                            // マーカーを非表示
                            touchMarker.gameObject.SetActive(false);
                        }
                    }
                    // 右タッチ
                    if(isRightTouch==true)
                    {
                        // 右半分をタッチした時の処理
                        cameraController.UpdateRightTouch(touch);
                    }
                }
            }
            else
            {
                isTouch=false;
            }
        }
        else
        {// PCキー入力取得
            horizontalKeyInput = Input.GetAxis("Horizontal");
            verticalKeyInput = Input.GetAxis("Vertical");
        }
        // プレイヤーの向きを調整
        bool isKeyInput = (horizontalKeyInput != 0|| verticalKeyInput !=0 || LeftTouchInput !=Vector2.zero);
        if(isKeyInput == true && isAttack==false)
        {
            bool currentIsRun=animator.GetBool("isRun");
            if(currentIsRun == false) animator.SetBool("isRun",true);
            Vector3 dir = rigid.velocity.normalized;
            dir.y=0;
            this.transform.forward = dir;
            Debug.Log("Run");
        }
        else
            {
                bool currentIsRun = animator.GetBool("isRun");
                if(currentIsRun == true)animator.SetBool("isRun",false);
            }
    }

    void FixedUpdate()
    {
        if(isAttack == false)
        {
            Vector3 input = new Vector3();
            Vector3 move = new Vector3();
            if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                input = new Vector3(LeftTouchInput.x,0,LeftTouchInput.y);
                move = input.normalized*2f;
            }
            else
            {
                input = new Vector3(horizontalKeyInput,0,verticalKeyInput);
                move = input.normalized * 2f;
            }
            
            Vector3 cameraMove = Camera.main.gameObject.transform.rotation * move;
            cameraMove.y=0;
            Vector3 currentRigidVelocity = rigid.velocity;
            currentRigidVelocity.y=0;

            rigid.AddForce(cameraMove-rigid.velocity,ForceMode.VelocityChange);
        }
        cameraController.FixedUpdateCameraPosition(this.transform);
    }
    
    public void OnAttackButtonClicked()
    {
        if(isAttack == false)
        {
            animator.SetTrigger("isAttack");
            isAttack = true;
        }
    }
    public void OnJumpButtonClicked()
    {
        if(isGround == true)
        {
            rigid.AddForce(Vector3.up*jumpPower,ForceMode.Impulse);
            Debug.Log("ジャンプボタンを押した");
        }
    }
    void OnFootTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Ground")
        {
            if(isGround == false) isGround =true;
            if(animator.GetBool("isGround")==false)animator.SetBool("isGround",true);
        }
    }
    void OnFootTriggerExit(Collider col)
    {
        if( col.gameObject.tag == "Ground")
        {
            isGround = false;
            animator.SetBool("isGround",false);
            Debug.Log("OnFootTriggerExit");
        }
    }
    void Anim_AttackHit()
    {
        Debug.Log("Hit");
        attackHit.SetActive(true);
    }
    void Anim_AttackEnd()
    {
        Debug.Log("End");
        attackHit.SetActive(false);
        isAttack = false;
    }

    
    
}

