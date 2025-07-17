using System;
using Unity.Android.Gradle;
using Unity.VisualScripting;
using UnityEngine;

public class ReadFile : MonoBehaviour
{
    Value value;
    string folder = "Bullets/";
    void Start()
    {
        value = GetComponent<Value>();
        ReadingFile("Pattern");

    }
    void ReadingFile(String file)
    {
        TextAsset File = Resources.Load<TextAsset>(folder + file);
        string[] lines = File.text.Split("\r\n");
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            if (line[0] == '/') continue;
            if (line[0] >= 'a' && line[0] <= 'z' || (line[0] >= 'A' && line[0] <= 'Z'))
            {
                ReadingFile(line);
                continue;
            }
            string[] parts = line.Trim().Split(';');

            float time = float.Parse(parts[0]);
            string[] xy = parts[1].Split(',');
            float x = float.Parse(xy[0]);
            float y = float.Parse(xy[1]);
            Vector2 pos = new Vector2(x, y);

            int dir = int.Parse(parts[2]);
            int type = int.Parse(parts[3]);

            Value.BulletData row = new Value.BulletData
            {
                time = time,
                pos = pos,
                dir = dir,
                type = type
            };

            value.Bullets.Add(row);
        }
    }
}
