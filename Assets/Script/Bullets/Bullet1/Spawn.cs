using UnityEngine;

public class Spawn : MonoBehaviour
{
    GameObject GameManager;
    public Shoot shoot;
    Vector3 dir;
    Vector3 pos;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        SetPos();
    }

    void SetPos()
    {
        dir = new Vector3(0f, 0f, 90f);
        float x = 0;
        float y = 0;
        pos = new Vector3(x, y, 0);

        transform.position = pos;
        transform.eulerAngles = dir;
    }
    void shooting()
    {
        shoot.enabled = true;
    }
}
