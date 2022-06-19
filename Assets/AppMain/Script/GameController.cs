using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // ゲームオーバーオブジェクト
    [SerializeField]GameObject gameOver = null;
    // プレイヤー
    [SerializeField] PlayerController player = null;
    // 敵リスト
    [SerializeField] List<Danger> enemys = new List<Danger>();
    // Start is called before the first frame update
    void Start()
    {
        player.GameOverEvent.AddListener(OnGameOver);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGameOver()
    {
        // ゲームオーバーを表示
        gameOver.SetActive(true);
        // プレイヤーを非表示
        player.gameObject.SetActive(false);
        // 敵の攻撃フラグを解除
        foreach(Danger enemy in enemys) enemy.IsBattle = false;
    }

    public void OnRetryButtonClicked()
    {
        // プレイヤーリトライ処理.
        player.Retry();
        // 敵のリトライ処理.
        foreach( Danger enemy in enemys ) enemy.OnRetry();
        // プレイヤーを表示.
        player.gameObject.SetActive( true );
        // ゲームオーバーを非表示.
        gameOver.SetActive( false );
    }
}
