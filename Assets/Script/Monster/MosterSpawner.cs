using UnityEngine;

public class MosterSpawner : MonoBehaviour
{
    [SerializeField] GameObject _monster;
    [SerializeField] GameObject _redPanel;

    public void Intan()
    {
        MonsterMovement monster = Instantiate(_monster, transform.position, Quaternion.identity).GetComponent<MonsterMovement>();
        monster.redPanel = _redPanel;
    }
}
