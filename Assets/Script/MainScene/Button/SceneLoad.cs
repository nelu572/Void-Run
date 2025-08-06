using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public ButtonSelected buttonSelected;
    int input;

    public List<string> Scenes;
    void Update()
    {
        input = buttonSelected.Selected_Index;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (input == 2)
            {
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false; // 에디터에서 실행 중일 때
                #else
                    Application.Quit(); // 빌드된 게임 실행 중일 때
                #endif
            }
            else
            {
                SceneManager.LoadScene(Scenes[input]);
            }
        }
    }
}
