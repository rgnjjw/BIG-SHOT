using UnityEngine;

public class BitMovement : MonoBehaviour
{
    Vector2 _target = new Vector2(15, -2f);
    [SerializeField] protected float _speed = 5f;

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * _speed;
        if (transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }
}
