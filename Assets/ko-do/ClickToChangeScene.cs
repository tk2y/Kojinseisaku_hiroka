using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [Header("シーン設定")]
    [Tooltip("クリックされた時に遷移するシーンの名前")]
    public string targetSceneName; // インスペクターに表示される変数

    [Tooltip("この機能を発動させるオブジェクトのタグ")]
    public string targetTag = "Doa"; // タグもインスペクターで設定可能に

    // マウスクリック時に呼び出される関数
    private void OnMouseDown()
    {
        // オブジェクトのタグが、インスペクターで指定したタグと一致するか確認
        if (gameObject.CompareTag(targetTag))
        {
            // targetSceneNameが空欄、またはnullでないかを確認
            if (string.IsNullOrEmpty(targetSceneName))
            {
                // 空欄だった場合は、エラーメッセージをコンソールに出力して処理を中断
                Debug.LogError("遷移先のシーン名が設定されていません！インスペクターを確認してください。");
                return;
            }

            // 問題がなければ、指定されたシーンに遷移
            Debug.Log(targetSceneName + " へシーンを切り替えます。");
            SceneManager.LoadScene(targetSceneName);
        }
    }
}