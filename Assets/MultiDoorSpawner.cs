using System.Collections.Generic; // Listを使うために必要
using UnityEngine;

public class MultiDoorSpawner : MonoBehaviour
{
    [Header("配置するドアのプレハブリスト")]
    [Tooltip("ここに移動先の異なるドアのプレハブをすべて登録します")]
    public List<GameObject> doorPrefabs;

    [Header("ドアを配置する場所リスト")]
    [Tooltip("ドアを配置する場所（Transform）をすべて登録します")]
    public List<Transform> spawnPoints;

    void Start()
    {
        // --- 事前チェック ---
        if (doorPrefabs.Count != spawnPoints.Count)
        {
            Debug.LogError("ドアのプレハブの数と、配置場所の数が一致していません！インスペクターの設定を確認してください。");
            return;
        }

        if (doorPrefabs.Contains(null) || spawnPoints.Contains(null))
        {
            Debug.LogError("リストに空の（None）要素が設定されています。インスペクターを確認してください。");
            return;
        }

        // --- 配置処理 ---
        List<GameObject> availableDoors = new List<GameObject>(doorPrefabs);

        foreach (Transform spawnPoint in spawnPoints)
        {
            int randomIndex = Random.Range(0, availableDoors.Count);
            GameObject doorToSpawn = availableDoors[randomIndex];

            Instantiate(doorToSpawn, spawnPoint.position, Quaternion.identity);

            availableDoors.RemoveAt(randomIndex);
        }

        Debug.Log(doorPrefabs.Count + "つのドアをランダムな位置に配置しました。");
    }
}