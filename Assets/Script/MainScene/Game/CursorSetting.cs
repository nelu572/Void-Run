using UnityEngine;

public class CursorSetting : MonoBehaviour
{
    public SettingsData settingsData;
    void Awake()
    {
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Debug.Log(settingsData.Music + " " + settingsData.SFX + " " + settingsData.LifeCount);
    }
}
