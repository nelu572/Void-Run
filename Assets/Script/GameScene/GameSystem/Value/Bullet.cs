using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public class Bullet1Data
    {
        public float time;
        public Vector2 pos;
        public int dir;
        public float speed;
    }
    public List<Bullet1Data> Bullet1 = new List<Bullet1Data>();
    public class Bullet2Data
    {
        public float time;
        public Vector2 pos;
        public int dir;
    }
    public List<Bullet2Data> Bullet2 = new List<Bullet2Data>();
}
