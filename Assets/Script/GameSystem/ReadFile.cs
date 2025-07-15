using UnityEngine;

public class ReadFile : MonoBehaviour
{
    Value value;
    void Start()
    {
        value = GetComponent<Value>();

        TextAsset File = Resources.Load<TextAsset>("BulletsPattern");
        string[] lines = File.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

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
