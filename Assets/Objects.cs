using UnityEngine;

public class Objects : MonoBehaviour
{
    public static Objects Instance;
    public bool IsIvs = false;
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

