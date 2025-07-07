using UnityEngine;

public class StartHealth : MonoBehaviour
{
    public static StartHealth Instance;
    public float _startHealth = 0.5f;
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
            return;
        }
    }
    public void UpStartHealth()
    {
        _startHealth += 0.1f;
    }

}
