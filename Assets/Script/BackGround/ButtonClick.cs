using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonClick : MonoBehaviour
{
    [SerializeField] Image[] images;
    [SerializeField] Ease ease;
    int value = 0;

    public void SceneMove(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        ScoreManager.Instance.ReStart();
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void ScoreUP()
    {

        if (CoinManager.Instance._coin >= 200 && AbLevel.Instance._scoreUpLevel == 1)
        {
            SoundManager.Instance.PlaySFX("OK");
            CoinManager.Instance._coin -= 200;
            AbLevel.Instance.score.text = "Score UP : 500";
            ScoreManager.Instance._plusScore++;
            AbLevel.Instance._scoreUpLevel++;
        }
        else if (CoinManager.Instance._coin >= 500 && AbLevel.Instance._scoreUpLevel == 2)
        {
            SoundManager.Instance.PlaySFX("OK");
            CoinManager.Instance._coin -= 500;
            ScoreManager.Instance._plusScore++;
            AbLevel.Instance.score.text = "Score UP : 1000";
            AbLevel.Instance._scoreUpLevel++;

        }
        else if (CoinManager.Instance._coin >= 1000 && AbLevel.Instance._scoreUpLevel == 3)
        {
            SoundManager.Instance.PlaySFX("OK");
            CoinManager.Instance._coin -= 1000;
            ScoreManager.Instance._plusScore++;
            AbLevel.Instance.score.text = "Score UP : Max";
            AbLevel.Instance._scoreUpLevel++;
        }
        else
        {
            SoundManager.Instance.PlaySFX("NO");
        }


    }
    public void HealthUP()
    {
        if (CoinManager.Instance._coin >= 50 && AbLevel.Instance._healthUPLevel == 1)
        {
            SoundManager.Instance.PlaySFX("OK");
            CoinManager.Instance._coin -= 50;
            StartHealth.Instance.UpStartHealth();
            AbLevel.Instance.hp.text = "Hp UP : 100";
            AbLevel.Instance._healthUPLevel++;
        }
        else if (CoinManager.Instance._coin >= 100 && AbLevel.Instance._healthUPLevel == 2)
        {
            SoundManager.Instance.PlaySFX("OK");
            CoinManager.Instance._coin -= 100;
            StartHealth.Instance.UpStartHealth();
            AbLevel.Instance.hp.text = "Hp UP : 150";
            AbLevel.Instance._healthUPLevel++;

        }
        else if (CoinManager.Instance._coin >= 150 && AbLevel.Instance._healthUPLevel == 3)
        {
            SoundManager.Instance.PlaySFX("OK");
            CoinManager.Instance._coin -= 150;
            StartHealth.Instance.UpStartHealth();
            AbLevel.Instance.hp.text = "Hp UP : 200";
            AbLevel.Instance._healthUPLevel++;


        }
        else if (CoinManager.Instance._coin >= 200 && AbLevel.Instance._healthUPLevel == 4)
        {
            SoundManager.Instance.PlaySFX("OK");
            CoinManager.Instance._coin -= 200;
            StartHealth.Instance.UpStartHealth();
            AbLevel.Instance.hp.text = "Hp UP : 250";
            AbLevel.Instance._healthUPLevel++;


        }
        else if (CoinManager.Instance._coin >= 250 && AbLevel.Instance._healthUPLevel == 5)
        {
            SoundManager.Instance.PlaySFX("OK");
            CoinManager.Instance._coin -= 250;
            StartHealth.Instance.UpStartHealth();
            AbLevel.Instance.hp.text = "Hp UP : Max";
            AbLevel.Instance._healthUPLevel++;

        }
        else
        {
            SoundManager.Instance.PlaySFX("NO");
        }


    }
    public void ItemUP()
    {
        if (CoinManager.Instance._coin >= 200 && AbLevel.Instance._itemUPLevel == 1)
        {
            SoundManager.Instance.PlaySFX("OK");
            CoinManager.Instance._coin -= 200;
            AbLevel.Instance.item.text = "Item UP : 500";
            Values.Instance.InvincibilityCount = 2;
            Values.Instance.PlusHp = 0.075f;
            AbLevel.Instance._itemUPLevel++;

        }
        else if (CoinManager.Instance._coin >= 500 && AbLevel.Instance._itemUPLevel == 2)
        {
            SoundManager.Instance.PlaySFX("OK");
            CoinManager.Instance._coin -= 500;
            AbLevel.Instance.item.text = "Item UP : 1000";
            Values.Instance.InvincibilityCount = 3;
            Values.Instance.PlusHp = 0.1f;
            AbLevel.Instance._itemUPLevel++;
        }
        else if (CoinManager.Instance._coin >= 1000 && AbLevel.Instance._itemUPLevel == 3)
        {
            SoundManager.Instance.PlaySFX("OK");
            CoinManager.Instance._coin -= 1000;
            AbLevel.Instance.item.text = "Item UP : Max";
            Values.Instance.InvincibilityCount = 4;
            Values.Instance.PlusHp = 0.15f;
            AbLevel.Instance._itemUPLevel++;
        }
        else
        {
            SoundManager.Instance.PlaySFX("NO");
        }

    }
    public void TutorialTrue()
    {
        SoundManager.Instance.PlaySFX("CLICK");
        for (int i = 0; i < 12; i++)
        {
            images[i].enabled = true;
        }
        transform.DOMoveY(1f, 1).SetEase(ease);

    }
    public void TutorialFalse()
    {
        SoundManager.Instance.PlaySFX("CLICK");
        value = 0;
        transform.DOMoveY(-10, 1).SetEase(ease);
    }
    public void TutorialNext()
    {
        SoundManager.Instance.PlaySFX("CLICK");
        if (value <= 15)
        {
            value++;
            images[value - 1].enabled = false;
        }
    }
    public void TutorialBack()
    {
        SoundManager.Instance.PlaySFX("CLICK");
        if (value > 0)
        {
            images[value - 1].enabled = true;
            value--;
        }
    }
}
