using UnityEngine;

public class Values : MonoBehaviour
{
    public static Values Instance;
    public float DamageValue = 0.2f;
    public int InvincibilityCount = 1;
    public float PlusHp = 0.05f;
    private void Awake()
    {
        // �̱��� �ν��Ͻ� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // �ߺ� �ν��Ͻ� ����
            return;
        }
    }
}

