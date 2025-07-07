using UnityEngine;

public class Invincibility : Item
{
    public GameObject eft;
    SpriteRenderer image;
    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySFX("SHIELDON");
            SetDamage();
        }
    }
    void SetDamage()
    {
        eft.SetActive(true);
        image.enabled = false;
    }

}
