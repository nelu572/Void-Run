using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IconMove : MonoBehaviour
{
    public SettingsData settingsData;

    public List<TextMeshProUGUI> Setting_Values;
    public List<GameObject> Setting_LeftArrows;
    public List<GameObject> Setting_RightArrows;

    public List<TextMeshProUGUI> Mode_Values;
    public List<GameObject> Mode_LeftArrows;
    public List<GameObject> Mode_RightArrows;

    public List<Animator> Kategorie_animators;
    public List<Animator> Setting_animators;
    public List<Animator> Mode_animators;

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
        Act();
        Kategorie_animation();
    }

    void Update()
    {

        int before_index = index;
        List<Vector3> before_con = condition;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (condition == Kategorie_pos && index == 3)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
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
            else if (condition == Setting_pos)
            {
                if (index == 2)
                {
                    if (Setting_Values[index].text == "OFF")
                    {
                        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                        Screen.fullScreen = true;
                        Setting_Values[index].text = "ON";
                    }
                    else
                    {
                        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
                        Setting_Values[index].text = "OFF";
                    }
                }
                else
                {
                    if (int.Parse(Setting_Values[index].text) < 10)
                    {
                        Setting_Values[index].text = (int.Parse(Setting_Values[index].text) + 1).ToString();
                    }
                    Setting_LeftArrows[index].SetActive(true);
                    if (int.Parse(Setting_Values[index].text) == 10)
                    {
                        Setting_RightArrows[index].SetActive(false);
                    }
                }
            }
            else if (condition == Mode_pos)
            {
                if (int.Parse(Mode_Values[index].text) < 5)
                {
                    Mode_Values[index].text = (int.Parse(Mode_Values[index].text) + 1).ToString();
                }
                Mode_LeftArrows[index].SetActive(true);
                if (int.Parse(Mode_Values[index].text) == 5)
                {
                    Mode_RightArrows[index].SetActive(false);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (condition == Setting_pos)
            {
                if (index == 2)
                {
                    if (Setting_Values[index].text == "OFF")
                    {
                        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                        Screen.fullScreen = true;
                        Setting_Values[index].text = "ON";
                    }
                    else
                    {
                        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
                        Setting_Values[index].text = "OFF";
                    }
                }
                else
                {
                    if (int.Parse(Setting_Values[index].text) > 0)
                    {
                        Setting_Values[index].text = (int.Parse(Setting_Values[index].text) - 1).ToString();
                    }
                    Setting_RightArrows[index].SetActive(true);
                    if (int.Parse(Setting_Values[index].text) == 0)
                    {
                        Setting_LeftArrows[index].SetActive(false);
                    }
                }
            }
            if (condition == Mode_pos)
            {
                if (int.Parse(Mode_Values[index].text) > 1)
                {
                    Mode_Values[index].text = (int.Parse(Mode_Values[index].text) - 1).ToString();
                }
                Mode_RightArrows[index].SetActive(true);
                if (int.Parse(Mode_Values[index].text) == 1)
                {
                    Mode_LeftArrows[index].SetActive(false);
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
            if (condition == Kategorie_pos && before_con == Kategorie_pos)
            {
                Kategorie_animation();
            }
            if ((condition == Kategorie_pos && index == 0) || condition == Setting_pos)
            {
                Setting_animation();
            }
            if ((condition == Kategorie_pos && index == 2) || condition == Mode_pos)
            {
                Mode_animation();
            }
        }

        settingsData.Music = int.Parse(Setting_Values[0].text);
        settingsData.SFX = int.Parse(Setting_Values[1].text);
        settingsData.LifeCount = int.Parse(Mode_Values[0].text);
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
    void Kategorie_animation()
    {
        for (int i = 0; i < Kategorie_animators.Count; i++)
        {
            if (i == index) Kategorie_animators[i].SetBool("Pressed", true);
            else Kategorie_animators[i].SetBool("Pressed", false);
        }
    }
    void Setting_animation()
    {
        if (condition == Setting_pos)
        {
            for (int i = 0; i < Setting_animators.Count; i++)
            {
                if (i == index) Setting_animators[i].SetBool("Pressed", true);
                else Setting_animators[i].SetBool("Pressed", false);
            }
        }
        else
        {
            for (int i = 0; i < Setting_animators.Count; i++)
            {
                Setting_animators[i].SetBool("Pressed", false);
            }
        }
    }
    void Mode_animation()
    {
        if (condition == Mode_pos)
        {
            for (int i = 0; i < Mode_animators.Count; i++)
            {
                if (i == index) Mode_animators[i].SetBool("Pressed", true);
                else Mode_animators[i].SetBool("Pressed", false);
            }
        }
        else
        {
            for (int i = 0; i < Mode_animators.Count; i++)
            {
                Mode_animators[i].SetBool("Pressed", false);
            }
        }
    }
}
