using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    public string scene;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(scene);
    }
}
