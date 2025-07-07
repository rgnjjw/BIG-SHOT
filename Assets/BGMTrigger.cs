using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMTrigger : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) // �� 1�� ������ ��
        {
            if (BGM.Instance != null)
            {
                BGM.Instance.ResetAndPlay();
            }
        }
    }
}
