using UnityEngine;

public class FJCollison : MonoBehaviour
{
    [SerializeField] BulletFirePos _fireFos;
    TempSystem _temp;
    private void Awake()
    {
        _temp = GetComponentInParent<TempSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_temp._canFire == true)
        {
            if (collision.CompareTag("Bit"))
            {
                Destroy(collision.gameObject);
                _fireFos.Fire();
            }
        }


    }
}
