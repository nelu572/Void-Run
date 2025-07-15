using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float Speed = 7;
    void Start()
    {
        this.enabled = false;
    }

    void shooting()
    {
        this.enabled = true;
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * Speed;

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1)
        {
            Destroy(gameObject);
        }
    }

}
