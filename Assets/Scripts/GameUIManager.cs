using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Button Settings;
    public Button Continue;
    public Button BackButton;
    public Button BackPausedButton;

    public GameObject PausePanel;
    public GameObject SettingsPanel;

    public Slider Volume;
    public Slider Brightness;

    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        Settings.onClick.AddListener(SettingsMenu);
        Continue.onClick.AddListener(ContinueGame);
        BackButton.onClick.AddListener(BackToMenu);

        BackPausedButton.onClick.AddListener(BackToPauseMenu);

        Volume.onValueChanged.AddListener(delegate {VolumeChangeCheck(); });
        Brightness.onValueChanged.AddListener(delegate {BrightnessChangeCheck(); });
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }
    
    void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
        SceneManager.UnloadSceneAsync("GameScene");
    }

    void SettingsMenu(){
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    void ContinueGame(){
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void PauseGame(){
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    void BackToPauseMenu(){
        SettingsPanel.SetActive(false);
        PausePanel.SetActive(true);
    }

    void VolumeChangeCheck(){
        music.volume = Volume.value;
    }

    void BrightnessChangeCheck(){
        Screen.brightness = Brightness.value;
    }
}
