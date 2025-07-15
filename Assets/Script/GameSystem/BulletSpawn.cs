using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class BulletSpawn : MonoBehaviour
{
    public List<GameObject> bullets;
    Value value;
    float N_Time = 0;
    public int index = 0;
    void Start()
    {
        value = GetComponent<Value>();

    }
    void Update()
    {
        if (index < value.Bullets.Count)
        {
            while (N_Time >= value.Bullets[index].time)
            {
                GameObject bullet = bullets[value.Bullets[index].type - 1];
                Vector3 position = new Vector3(value.Bullets[index].pos.x, value.Bullets[index].pos.y, 0);
                Quaternion rotation = Quaternion.Euler(0f, 0f, value.Bullets[index].dir * 90f);
                if (bullet == null)
                    Debug.Log(value.Bullets[index].type - 1);
                Instantiate(bullet, position, rotation);
                index++;
                if (index >= value.Bullets.Count) break;
            }
            N_Time += Time.deltaTime;
        }
    }
}
