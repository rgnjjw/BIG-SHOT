using UnityEngine;

public class Coin : Item
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySFX("COIN");
            CoinManager.Instance.PlusCoin(CoinManager.Instance._coinValue);
            CoinManager.Instance._roundCoin += 10;
            Destroy(gameObject);
        }
    }
}
