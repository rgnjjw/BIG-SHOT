using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipAndName
{
    public AudioClip clip;
    public string name;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private List<ClipAndName> clips;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource BGMSource;
    private Dictionary<string, AudioClip> _audioDict = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        DictInit();
    }
    private void DictInit()
    {
        foreach (var clip in clips)
        {
            _audioDict.Add(clip.name, clip.clip);
        }
    }
    public void PlaySFX(string name)
    {
        float volume = 1f;

        // 특정 이름의 소리만 볼륨 줄이기
        if (name == "JELLY")
            volume = 0.3f;

        if (_audioDict.TryGetValue(name, out var audioClip))
        {
            SFXSource.PlayOneShot(audioClip, volume);
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
