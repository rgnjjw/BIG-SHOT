using UnityEngine;

public class _hpUp : Item
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health hp))
        {
            SoundManager.Instance.PlaySFX("HP");
            hp.Heal(0.05f);
            Destroy(gameObject);
        }
    }
}
