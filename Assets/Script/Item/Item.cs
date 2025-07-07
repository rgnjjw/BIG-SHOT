using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float _radius;
    [SerializeField] float _speed = 5;

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * _speed;
        ObsCut();
        if (Vector3.Distance(transform.position, new Vector3(-14, 0, 0)) < 0.01f)
        {
            Destroy(gameObject);
        }
    }
    private void ObsCut()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Obs"))
            {
                Destroy(hit.gameObject);
            }
        }

    }
}
