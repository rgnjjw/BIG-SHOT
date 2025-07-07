using System.Collections;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM Instance;
    public AudioSource BGMSource;

    private void Awake()
    {
        BGMSource = GetComponent<AudioSource>();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        ResetAndPlay(); // 씬이 로드될 때마다 BGM 초기화 및 재생
    }

    public void ResetAndPlay()
    {
        BGMSource.pitch = 1f;

        if (!BGMSource.isPlaying)
        {
            BGMSource.Play();
        }
    }

    public Coroutine Die()
    {
        return StartCoroutine(DieRoutine());
    }

    private IEnumerator DieRoutine()
    {
        while (BGMSource.pitch > 0.03f)
        {
            BGMSource.pitch /= 1.01f;
            yield return null;
        }
        BGMSource.Stop();
    }
}
