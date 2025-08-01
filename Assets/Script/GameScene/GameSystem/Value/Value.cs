using UnityEngine;

public class Value : MonoBehaviour
{
    public GameObject Ground;
    public GameObject Player;
    public Vector2 Map_SIZE;
    public Vector2 Player_SIZE;

    public float x_boundary;
    public float y_boundary;

    public float time = 0;
    void Start()
    {
        Fix_MapSize();
    }
    void Update()
    {
        time = Time.deltaTime;
    }
    public void Fix_MapSize()
    {
        Map_SIZE = new Vector2(Ground.transform.localScale.x, Ground.transform.localScale.y);
        Player_SIZE = new Vector2(Player.transform.localScale.x, Player.transform.localScale.y);
        x_boundary = Map_SIZE.x / 2 - Player_SIZE.x / 2;
        y_boundary = Map_SIZE.y / 2 - Player_SIZE.y / 2;
    }
}
