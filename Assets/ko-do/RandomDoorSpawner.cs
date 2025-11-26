using UnityEngine;

public class RandomDoorSpawner : MonoBehaviour
{
    [Header("配置するドアのプレハブ")]
    [Tooltip("stage1へ移動するドアのプレハブ")]
    public GameObject stage1DoorPrefab;

    [Tooltip("stage3へ移動するドアのプレハブ")]
    public GameObject stage3DoorPrefab;


    [Header("ドアを配置する場所")]
    [Tooltip("ドアを配置する場所 A")]
    public Transform spawnPointA;

    [Tooltip("ドアを配置する場所 B")]
    public Transform spawnPointB;

    // ゲーム開始時に一度だけ呼び出される
    void Start()
    {
        // プレハブや配置場所が設定されているかチェック
        if (stage1DoorPrefab == null || stage3DoorPrefab == null || spawnPointA == null || spawnPointB == null)
        {
            Debug.LogError("プレハブまたは配置場所がインスペクターで設定されていません！");
            return; // 設定が不十分な場合は処理を中断
        }

        // 0か1のランダムな整数を生成
        int randomPattern = Random.Range(0, 2);

        // randomPatternの値によって配置を決定
        if (randomPattern == 0)
        {
            // パターン1: 場所Aにstage1行き、場所Bにstage3行きのドアを配置
            Instantiate(stage1DoorPrefab, spawnPointA.position, Quaternion.identity);
            Instantiate(stage3DoorPrefab, spawnPointB.position, Quaternion.identity);
            Debug.Log("配置パターン1: 場所Aにstage1行き、場所Bにstage3行き");
        }
        else
        {
            // パターン2: 場所Aにstage3行き、場所Bにstage1行きのドアを配置
            Instantiate(stage3DoorPrefab, spawnPointA.position, Quaternion.identity);
            Instantiate(stage1DoorPrefab, spawnPointB.position, Quaternion.identity);
            Debug.Log("配置パターン2: 場所Aにstage3行き、場所Bにstage1行き");
        }
    }
}