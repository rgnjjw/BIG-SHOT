using System.Collections;
using UnityEngine;

public class SlideObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject _slideObstacle;
    [SerializeField] GameObject redPanel;
    public IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SlideObstacle obstacle = Instantiate(_slideObstacle, transform.position, Quaternion.identity).GetComponent<SlideObstacle>();
        obstacle._redPanel = redPanel;
    }
}
