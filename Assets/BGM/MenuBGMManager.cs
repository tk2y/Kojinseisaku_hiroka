using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBGMManager : MonoBehaviour
{
    public static MenuBGMManager instance;
    public AudioClip bgmClip;
    private AudioSource audioSource;

    void Awake()
    {
        // ▼▼▼ 修正ポイント：重複チェックを強化 ▼▼▼
        if (instance != null && instance != this)
        {
            // すでに他にある場合、この新しいオブジェクトの音を強制的に止める
            AudioSource myAudio = GetComponent<AudioSource>();
            if (myAudio != null) myAudio.Stop();

            // 即座に自分を破棄
            Destroy(gameObject);
            return;
        }
        // ▲▲▲▲▲▲

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = bgmClip;
        audioSource.loop = true;

        // コードから制御するので、ここでも念のため自動再生をオフにする
        audioSource.playOnAwake = false;
    }

    void Start()
    {
        CheckSceneAndPlay(SceneManager.GetActiveScene());
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckSceneAndPlay(scene);
    }

    void CheckSceneAndPlay(Scene scene)
    {
        string sceneName = scene.name;

        if (sceneName == "Start scene" || sceneName == "start screen")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}