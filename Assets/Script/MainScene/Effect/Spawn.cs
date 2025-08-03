using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> Effects;
    public Transform parentObject;
    float t = 0;
    float Timing = 0;
    void Update()
    {
        t += Time.deltaTime;
        if (t > Timing)
        {
            Timing = Random.Range(0.3f, 0.7f);
            t = 0;
            foreach (GameObject effect in Effects)
            {
                Vector3 pos = new Vector3(Random.Range(-8f, 8f), -5, 0);
                Quaternion dir = Quaternion.Euler(0, 0, 0);
                GameObject created = Instantiate(effect, pos, dir);

                Destroy(created, 3.5f);
                created.GetComponent<Move>().Speed = Random.Range(0.5f, 1.5f);
                created.transform.SetParent(parentObject, false);
            }
        }
    }
}
