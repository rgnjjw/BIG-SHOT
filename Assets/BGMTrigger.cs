using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMTrigger : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) // 씬 1로 들어왔을 때
        {
            if (BGM.Instance != null)
            {
                BGM.Instance.ResetAndPlay();
            }
        }
    }
}
