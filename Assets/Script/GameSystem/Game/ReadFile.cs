using System.Collections.Generic;
using UnityEngine;

public class ReadFile : MonoBehaviour
{
    public List<TextAsset> Files;
    public GameObject ValueManager;
    Bullet bullet;
    void Start()
    {
        bullet = ValueManager.GetComponent<Bullet>();
        foreach (TextAsset File in Files)
        {
            string[] lines = File.text.Split("\r\n");
            if (lines[0] == "Bullet1") Bullet1(lines);
        }
    }
    void Bullet1(string[] lines)
    {
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line == "Bullet1") continue;
            string[] parts = line.Trim().Split(';');

            float time = float.Parse(parts[0]);
            string[] xy = parts[1].Split(',');
            float x = float.Parse(xy[0]);
            float y = float.Parse(xy[1]);
            Vector2 pos = new Vector2(x, y);

            int dir = int.Parse(parts[2]);
            int type = int.Parse(parts[3]);
            float speed = float.Parse(parts[4]);
            Bullet.Bullet1Data row = new Bullet.Bullet1Data
            {
                time = time,
                pos = pos,
                dir = dir,
                type = type,
                speed = speed
            };

            bullet.Bullet1.Add(row);
        }
    }
}
