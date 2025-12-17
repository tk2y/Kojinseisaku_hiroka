using UnityEngine;
using UnityEngine.SceneManagement; // ★これが必要です

public class SceneChanger1 : MonoBehaviour
{
    // ボタンから呼び出すための関数（publicにする必要があります）
    public void GoToStartScreen()
    {
        // "StartScreen" の部分は移動したいシーンの名前と完全に一致させてください
        SceneManager.LoadScene("StartScreen");
    }
}