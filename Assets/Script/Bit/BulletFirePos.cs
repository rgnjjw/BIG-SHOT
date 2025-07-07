using UnityEngine;

public class BulletFirePos : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _fireEft;

    public void Fire()
    {
        Instantiate(_bullet, transform.position, Quaternion.Euler(0, 0, 90));
        Instantiate(_fireEft, transform);
        SoundManager.Instance.PlaySFX("FIRE");
    }

}
