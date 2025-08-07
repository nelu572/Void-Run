using UnityEngine;

public class Bullet2Move : MonoBehaviour
{
    BoxCollider2D col = new BoxCollider2D();
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        col.enabled = false;
    }
    void Shoot()
    {
        col.enabled = true;
        Destroy(gameObject, 0.5f);
    }
}
