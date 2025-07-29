using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public class Bullet1Data
    {
        public float time;
        public Vector2 pos;
        public int dir;
        public int type;
        public float speed;
    }
    public List<Bullet1Data> Bullet1 = new List<Bullet1Data>();
}
