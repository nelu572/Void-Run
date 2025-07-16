using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    Animator anim;

    public float max_hp = 3;
    float hp;

    public float invTime = 3;
    float i_time = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
        hp = max_hp;
    }
    void Update()
    {

        if (i_time > 0)
        {
            i_time -= Time.deltaTime;
            if (i_time <= 0)
            {
                i_time = 0;
                anim.SetBool("Hit", false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullets") && i_time == 0)
        {
            hp--;
            if (hp <= 0) Debug.Log(hp);

            i_time = invTime;
            anim.SetBool("Hit", true);
        }
    }
}
