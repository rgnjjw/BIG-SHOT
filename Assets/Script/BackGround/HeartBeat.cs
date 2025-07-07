using DG.Tweening;
using System.Collections;
using UnityEngine;
public class HeartBeat : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(HeartBeating());
    }
    IEnumerator HeartBeating()
    {
        while (true)
        {
            yield return transform.DOScale(1.3f, 0.8f).WaitForCompletion();
            yield return transform.DOScale(1, 0.8f).WaitForCompletion();
        }

    }

}
