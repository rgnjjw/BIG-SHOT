using System.Collections;
using UnityEngine;

public class BloodSpot : MonoBehaviour
{
    [SerializeField] GameObject _bloodEft;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            StartCoroutine(Blood());
        }
    }
    IEnumerator Blood()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(_bloodEft, transform);
    }
}
