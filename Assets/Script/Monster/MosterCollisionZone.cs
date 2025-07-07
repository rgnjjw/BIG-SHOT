using UnityEngine;

public class MosterCollisionZone : MonoBehaviour
{
    [SerializeField] MosterSpawner _mosterSpawner;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bit"))
        {
            _mosterSpawner.Intan();
        }
    }
}
