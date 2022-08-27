using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // ゲームオーバーオブジェクト
    [SerializeField]GameObject gameOver = null;
    // ゲームクリアオブジェクト
    [SerializeField]GameObject gameClear = null;
    // プレイヤー
    [SerializeField] PlayerController player = null;
    // 敵リスト
    [SerializeField] List<Danger> enemys = new List<Danger>();
    // 敵プレハブリスト
    [SerializeField] List<GameObject> enemyPrefabList = new List<GameObject>();
    // 敵出現時リスト
    [SerializeField] List<Transform> enemyGateList = new List<Transform>();
    // フィールド上にいる敵リスト
    List<EnemyBase> fieldEnemys = new List<EnemyBase>(); 
    // ゲームクリア画面での時間表示テキスト
    [SerializeField] Text gameClearTimeText = null;
    // 通常時の画面に時間表示するためのテキスト
    [SerializeField] Text timerText = null;
    // 敵の移動ターゲットリスト.
    [SerializeField] List<Transform> enemyTargets = new List<Transform>();
 

    // 現在の時間
    float currentTime = 0;
    // 時間計測フラグ
    bool isTimer = false;

    // 敵自動生成フラグ
    bool isEnemySpawn = false;
    //現在の敵撃破数
    int currentBossCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        player.GameOverEvent.AddListener(OnGameOver);
        gameOver.SetActive(false);
        CreateEnemy();
        CreateEnemy();
        foreach( var enemy in enemys )
        {
            enemy.ArrivalEvent.AddListener( EnemyMove );
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimer==true){
            currentTime+=Time.deltaTime;
            if(currentTime>999.9f)timerText.text="999.9";
            else timerText.text = currentTime.ToString("000.0");
        }
    }

    void OnGameOver()
    {
        isTimer = false;
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

        // 敵のリトライ処理.
        // foreach( EnemyBase enemy in enemys ) enemy.OnRetry();
        // フィールド上の敵を削除しリストをリセット.
        foreach( EnemyBase enemy in fieldEnemys ) 
        {
            Destroy( enemy.gameObject );
        }
        fieldEnemys.Clear();

        Init();
    }

    void CreateEnemy()
    {
        var num = Random.Range(0,enemyPrefabList.Count);
        var Prefab = enemyPrefabList[num];

        var PosNum = Random.Range(0,enemyGateList.Count);
        var pos = enemyGateList[PosNum];

        var obj = Instantiate(prefab,pos.position,Quaternion.identity);
        var enemy = obj.GetComponent<EnemyBase>();

        enemy.ArrivalEvent.AddListener(EnemyBase);
        enemy.DestroyEvent.AddListener(EnemyDestroy);

        fieldEnemys.Add(enemy);
    }

    void EnemyDestroy(EnemyBase enemy)
    {
        if(fieldEnemys.Contains(enemy) == true)
        {
            fieldEnemys.Remove(enemy);
        }
        if(enemy.IsBoss == false){
            currentBossCount++;
            if (currentBossCount > 10)
            {
                CreateBoss();
            }
        }
        else{
            Debug.Log("GameClear!!");
            isTimer = false;

            if(currentTime > 999f)gameClearTimeText.text = "Time:999.9";
            else gameClearTimeText.text = "Time :"+ currentTime.ToStrong("000.0");
            // ゲームクリアを表示
            GameClear.SetActive(true);

            isEnemySpawn = false;
            // フィールド上の敵を削除しリストをリセット
            foreach(EnemyBase e in fieldsEnemys)
            {
                Destroy(e.gameObject);
            }
            fieldEnemys.Clear();
        }
        Destroy(enemy.gameObject);
    }

    void Init()
    {
        Debug.Log("初期化処理開始");
        currentTime = 0;
        isTimer = true;
        timerText ="000.0";

        isEnemySpawn = true;
        StartCoroutine(EnemyCreateLoop());
        currentBossCount = 0;

        currentTime = 0;
        isTimer = true;
        timerText.text = "0.00";

    }
    // ---------------------------------------------------------------------
    /// <summary>
    /// リストからランダムにターゲットを取得.
    /// </summary>
    /// <returns> ターゲット. </returns>
    // ---------------------------------------------------------------------
    Transform GetEnemyMoveTarget()
    {
        if( enemyTargets == null || enemyTargets.Count == 0 ) return null;
        else if( enemyTargets.Count == 1 ) return enemyTargets[0];
        
        int num = Random.Range( 0, enemyTargets.Count );
        return enemyTargets[ num ];
    }
    // ---------------------------------------------------------------------
    /// <summary>
    /// 敵に次の目的地を設定.
    /// </summary>
    /// <param name="enemy"> 敵. </param>
    // ---------------------------------------------------------------------
    void EnemyMove( EnemyBase enemy )
    {
        var target = GetEnemyMoveTarget();
        if( target != null ) enemy.SetNextTarget( target );
    }

}


