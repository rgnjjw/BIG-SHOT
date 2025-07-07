using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpot : MonoBehaviour
{
    [SerializeField] List<GameObject> _obstacles;
    [SerializeField] SlideObstacleSpawner _slideSpawner;
    [SerializeField] float _waitTime1;
    [SerializeField] float _waitTime2;
    [SerializeField] GameObject _redPanel;
    public bool _canCreate = true;
    private int count = 0;
    private float _randomTime;
    private float _time;
    private bool _can = true;
    private bool _check = false;
    private float _leveltimer = 0;
    private int _level = 0;
    private float _createTime = 0;
    private void Start()
    {
        _level = 0;
    }
    private void Awake()
    {
        _randomTime = Random.Range(1, 5);
    }

    private void Update()
    {
        _leveltimer += Time.deltaTime;
        if (_leveltimer >= 60)
        {
            _level++;
            _leveltimer = 0;
        }
        if (_level == 1)
        {
            _createTime = 0.3f;
        }
        else if (_level == 2)
        {
            _createTime = 0.6f;
        }
        else if (_level == 3)
        {
            _createTime = 0.9f;
        }
        else
        {
            _createTime = 0;
        }
        _time += Time.deltaTime;

        if (_time >= _randomTime)
        {
            _randomTime = Random.Range(1, 3f);
            int value = Random.Range(0, 5);

            _time = _createTime;
            // 80% 확률로 value = 1
            if (value <= 3)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }


            if (count == 0)
            {
                StartCoroutine(WaitCreate());
            }
            else
            {
                Obstacle obstacle = Instantiate(_obstacles[value], transform).GetComponent<Obstacle>();
                obstacle.redPanel = _redPanel;
            }

            // 슬라이드 장애물 생성 조건 체크 (count 증가 전에!)
            if (value == 1 && _canCreate && count == 3)
            {
                if (_slideSpawner != null)
                {
                    StartCoroutine(_slideSpawner.Wait(1f));
                    _canCreate = false;
                }
            }

            _can = value == 1;
            count++;

            if (count > 3)
            {
                count = 0;
                _canCreate = true;
            }
        }
    }

    IEnumerator WaitCreate()
    {
        yield return new WaitForSeconds(2);
        Obstacle obstacle = Instantiate(_obstacles[1], transform).GetComponent<Obstacle>();
        obstacle.redPanel = _redPanel;
    }
}