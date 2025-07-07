using UnityEngine;

public class ObsCol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jelley"))
        {
            Destroy(collision.gameObject);
        }
    }
}
