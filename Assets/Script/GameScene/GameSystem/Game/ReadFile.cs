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
            if (lines[0] == "Bullet2") Bullet2(lines);
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
            float speed = float.Parse(parts[3]);
            Bullet.Bullet1Data row = new Bullet.Bullet1Data
            {
                time = time,
                pos = pos,
                dir = dir,
                speed = speed
            };

            bullet.Bullet1.Add(row);
        }
    }
    void Bullet2(string[] lines)
    {
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line == "Bullet2") continue;
            string[] parts = line.Trim().Split(';');

            float time = float.Parse(parts[0]);
            string[] xy = parts[1].Split(',');
            float x = float.Parse(xy[0]);
            float y = float.Parse(xy[1]);
            Vector2 pos = new Vector2(x, y);

            int dir = int.Parse(parts[2]);
            Bullet.Bullet2Data row = new Bullet.Bullet2Data
            {
                time = time,
                pos = pos,
                dir = dir
            };

            bullet.Bullet2.Add(row);
        }
    }
}
