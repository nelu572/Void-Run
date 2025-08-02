using System.Collections.Generic;
using UnityEngine;

public class ButtonSelected : MonoBehaviour
{
    public List<Animator> buttons;
    int Selected_Index = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Selected_Index++;
            if (Selected_Index > buttons.Count - 1)
            {
                Selected_Index = buttons.Count - 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Selected_Index--;
            if (Selected_Index < 0)
            {
                Selected_Index = 0;
            }
        }
        for (int i = 0; i < buttons.Count; i++)
        {

            if (i == Selected_Index) buttons[i].SetBool("Pressed", true);
            else buttons[i].SetBool("Pressed", false);
        }
    }
}
