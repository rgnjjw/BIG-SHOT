using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class ObsDelete : MonoBehaviour
{
    [SerializeField] GameObject bluePanel;
    [SerializeField] CinemachineImpulseSource _carmara;

    private int _count;
    private bool _isEnding = false;

    private void OnEnable()
    {
        if (Values.Instance != null)
        {
            _count = Values.Instance.InvincibilityCount;
        }
        else
        {
            Debug.LogWarning("Values.Instance is null!");
            _count = 0;
        }

        _isEnding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_count <= 0 || _isEnding) return;

        if (collision.CompareTag("Obs") || collision.CompareTag("Monster") || collision.CompareTag("SlidObs"))
        {
            SoundManager.Instance?.PlaySFX("SHIELDHIT");
            Destroy(collision.gameObject);
            _carmara?.GenerateImpulse();
            StartCoroutine(BluePanel());

            _count--;

            if (_count <= 0)
            {
                StartCoroutine(EndAfterFrame());
            }
        }
    }

    private IEnumerator BluePanel()
    {
        if (bluePanel != null)
        {
            bluePanel.SetActive(true);
            yield return new WaitForSeconds(0.43f);
            bluePanel.SetActive(false);
        }
    }

    private IEnumerator EndAfterFrame()
    {
        _isEnding = true;
        yield return new WaitForEndOfFrame();
        SetActiveFalse();
    }

    private void SetActiveFalse()
    {
        gameObject.SetActive(false);
        if (bluePanel != null)
            bluePanel.SetActive(false);
    }
}
