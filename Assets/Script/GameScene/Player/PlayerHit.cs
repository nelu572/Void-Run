using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    public SettingsData settingsData;

    public List<GameObject> HP_Icon;

    public List<Animator> HP_Anima;

    Animator anim;

    float max_hp;
    float hp;

    public float invTime = 3;
    float i_time = 0;
    void Start()
    {
        max_hp = settingsData.LifeCount;
        anim = GetComponent<Animator>();
        hp = max_hp;
        IconDel();
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
    void IconDel()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (hp < i) HP_Icon[i - 1].SetActive(false);
            else HP_Icon[i - 1].SetActive(true);
        }
    }
    void IconAnimation()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (hp < i) HP_Anima[i - 1].SetBool("empty", true);
            else HP_Anima[i - 1].SetBool("empty", false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullets") && i_time == 0)
        {
            hp--;
            if (hp <= 0) Debug.Log("님 주금");
            IconAnimation();
            i_time = invTime;
            anim.SetBool("Hit", true);
        }
    }
}
