using System.Collections;
using UnityEngine;

public class JellySpawner : MonoBehaviour
{
    [SerializeField] GameObject _jelley;
    [SerializeField] float _maxtime;
    bool _isCanSpawn = true;
    float _timer = 0;

    private void Update()
    {
        if (!_isCanSpawn)//~가 아니라면 함수실행끝
            return;
        _timer += Time.deltaTime;
        if (_timer >= _maxtime)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0); // z좌표 조정
            ScoreJelley scoreJelly = Instantiate(_jelley, spawnPos, Quaternion.identity).GetComponent<ScoreJelley>();
            _timer = 0;
        }

    }
    public IEnumerator OstacleWait1(float waitTime)
    {
        _isCanSpawn = false;
        yield return new WaitForSeconds(waitTime);
        _isCanSpawn = true;
        Debug.Log("dfaffdas");
    }
    public IEnumerator OstacleWait2(float waitTime)
    {
        _isCanSpawn = false;
        yield return new WaitForSeconds(waitTime);
        _isCanSpawn = true;
        Debug.Log("dfaffdas");
    }
}
