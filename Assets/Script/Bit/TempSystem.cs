using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TempSystem : MonoBehaviour
{
    [SerializeField] Image tempUI;
    [SerializeField] TextMeshProUGUI _over;
    [SerializeField] Color startColor = Color.green;
    [SerializeField] Color endColor = Color.red;

    private float _timer = 0;
    public bool _canFire = true;

    private Coroutine _rechargeCoroutine;
    private bool _isRecharging = false;

    private void Start()
    {
        tempUI.fillAmount = 0;
        tempUI.color = startColor;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_canFire && tempUI.fillAmount < 1)
        {
            // Ű �Է� ó��
            if (Keyboard.current.fKey.wasPressedThisFrame || Keyboard.current.jKey.wasPressedThisFrame)
            {
                _timer = 0f;
                tempUI.fillAmount += 0.05f;
                tempUI.fillAmount = Mathf.Clamp01(tempUI.fillAmount);

                // ���� ����
                Color targetColor = Color.Lerp(startColor, endColor, tempUI.fillAmount);
                tempUI.DOColor(targetColor, 0.2f);

                // ���� ���̶�� �ߴ�
                if (_isRecharging)
                {
                    StopCoroutine(_rechargeCoroutine);
                    _isRecharging = false;
                }
            }

            // ���� ����: �Է� ���� 1.5�� ���
            if (_timer >= 1.5f && !_isRecharging)
            {
                _rechargeCoroutine = StartCoroutine(ReCharge());
            }

            // �ִ�ġ ���� ��
            if (tempUI.fillAmount >= 1)
            {
                tempUI.fillAmount = 1;

                if (_isRecharging)
                {
                    StopCoroutine(_rechargeCoroutine);
                    _isRecharging = false;
                }

                StartCoroutine(RollBack());
            }
        }
    }

    IEnumerator RollBack()
    {
        _canFire = false;
        _over.gameObject.SetActive(true);

        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.05f);
            tempUI.fillAmount -= 0.01f;
            tempUI.fillAmount = Mathf.Clamp01(tempUI.fillAmount);

            // ���� ����
            Color targetColor = Color.Lerp(startColor, endColor, tempUI.fillAmount);
            tempUI.DOColor(targetColor, 0.05f);
        }

        _over.gameObject.SetActive(false);
        _canFire = true;
    }

    IEnumerator ReCharge()
    {
        _isRecharging = true;

        while (tempUI.fillAmount > 0 && _timer >= 1.5f)
        {
            tempUI.fillAmount -= 0.1f * Time.deltaTime;
            tempUI.fillAmount = Mathf.Clamp01(tempUI.fillAmount);

            // ���� ����
            Color targetColor = Color.Lerp(startColor, endColor, tempUI.fillAmount);
            tempUI.DOColor(targetColor, 0.1f);

            yield return null;
        }

        _isRecharging = false;
    }
}
