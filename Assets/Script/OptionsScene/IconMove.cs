using System.Collections.Generic;
using UnityEngine;

public class IconMove : MonoBehaviour
{
    public List<Vector3> Kategorie_pos;
    public List<Vector3> Setting_pos;
    public List<Vector3> Mode_pos;

    List<Vector3> condition;
    int index = 0;

    public GameObject Setting_Panel;
    public GameObject Control_Panel;
    public GameObject Mode_Panel;
    void Start()
    {
        index = 0;
        condition = Kategorie_pos;
        transform.position = condition[index];
    }

    void Update()
    {
        int before_index = index;
        List<Vector3> before_con = condition;
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            index++;
            if (index > condition.Count - 1)
            {
                index = condition.Count - 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            index--;
            if (index < 0)
            {
                index = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (condition == Kategorie_pos)
            {
                if (index == 0)
                {
                    index = 0;
                    condition = Setting_pos;
                }
                if (index == 2)
                {
                    index = 0;
                    condition = Mode_pos;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (condition == Setting_pos)
            {
                index = 0;
                condition = Kategorie_pos;
            }
            if (condition == Mode_pos)
            {
                index = 2;
                condition = Kategorie_pos;
            }
        }

        if (index != before_index || condition != before_con)
        {
            Act();
        }
    }
    void Act()
    {
        transform.position = condition[index];
        Open_Panel();
    }
    void Open_Panel()
    {
        if (condition == Kategorie_pos)
        {
            if (index == 0)
            {
                Setting_Panel.SetActive(true);
                Control_Panel.SetActive(false);
                Mode_Panel.SetActive(false);
            }
            else if (index == 1)
            {
                Setting_Panel.SetActive(false);
                Control_Panel.SetActive(true);
                Mode_Panel.SetActive(false);
            }
            else if (index == 2)
            {
                Setting_Panel.SetActive(false);
                Control_Panel.SetActive(false);
                Mode_Panel.SetActive(true);
            }
            else
            {
                Setting_Panel.SetActive(false);
                Control_Panel.SetActive(false);
                Mode_Panel.SetActive(false);
            }
        }
    }
}
