using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalSceneManager : MonoBehaviour
{
    public Text timeDisplay; // UnityエディタでTextコンポーネントをアタッチする
    public Button backToStartButton; // Unityエディタでボタンをアタッチする

    void Start()
    {
        if (TimerManager.Instance != null)
        {
            float finalTime = TimerManager.Instance.elapsedTime;
            // 例: 00:00.000 の形式で表示
            int minutes = Mathf.FloorToInt(finalTime / 60);
            int seconds = Mathf.FloorToInt(finalTime % 60);
            int milliseconds = Mathf.FloorToInt((finalTime * 1000) % 1000);
            timeDisplay.text = string.Format("タイム: {0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
        }
        else
        {
            timeDisplay.text = "タイム: エラー (TimerManagerが見つかりません)";
        }

        if (backToStartButton != null)
        {
            backToStartButton.onClick.AddListener(OnBackToStartButtonClicked);
        }
    }

    void OnBackToStartButtonClicked()
    {
        // TimerManagerを破棄せず、スタートシーンに戻る
        SceneManager.LoadScene("StartScene");
    }
}