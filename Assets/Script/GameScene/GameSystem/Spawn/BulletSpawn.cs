using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletSpawn : MonoBehaviour
{
    public GameObject ValueManger;
    Value value;
    Bullet bullets;

    [SerializeField] Bullet1 bullet1;
    float t = 0;
    void Start()
    {
        value = ValueManger.GetComponent<Value>();
        bullets = ValueManger.GetComponent<Bullet>();
    }
    void Update()
    {
        t = value.time;
        bullet1.Spawn(bullets.Bullet1, t);
    }
    [System.Serializable]
    private class Bullet1
    {
        int index = 0;
        public GameObject bullet;

        public void Spawn(List<Bullet.Bullet1Data> Pattern, float t)
        {
            if (index < Pattern.Count)
            {
                if (Pattern[index].time < t)
                {
                    Vector3 pos = new Vector3(Pattern[index].pos.x, Pattern[index].pos.y, 0);
                    Quaternion dir = Quaternion.Euler(0, 0, Pattern[index].dir);
                    Debug.Log(bullet);
                    GameObject obj = Instantiate(bullet, pos, dir);
                    Shoot shoot = obj.GetComponent<Shoot>();
                    if (shoot != null) shoot.Speed = Pattern[index].speed;
                    index++;
                }
            }
        }
    }
}
