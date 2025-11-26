using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理のために必要

public class SceneLoader : MonoBehaviour
{
    // Start Screenシーンに移動するメソッド
    public void LoadStartScreen()
    {
        // タイマーを開始
        if (TimerManager.Instance != null)
        {
            TimerManager.Instance.StartTimer();
        }

        // ここに移動したいシーンの名前を指定
        SceneManager.LoadScene("stage1");
    }
}