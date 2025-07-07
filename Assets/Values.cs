using UnityEngine;

public class Values : MonoBehaviour
{
    public static Values Instance;
    public float DamageValue = 0.2f;
    public int InvincibilityCount = 1;
    public float PlusHp = 0.05f;
    private void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // 중복 인스턴스 제거
            return;
        }
    }
}

