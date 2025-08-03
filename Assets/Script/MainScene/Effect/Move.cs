using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
    }
}
