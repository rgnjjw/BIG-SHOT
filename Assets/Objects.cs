using UnityEngine;

public class Objects : MonoBehaviour
{
    public static Objects Instance;
    public bool IsIvs = false;
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

