using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject settingsPanel;

    [Header("Buttons")]
    public GameObject pauseButton;

    [Header("Audio")]
    public AudioSource bgmSource;
    public AudioSource[] sfxSources;

    [Header("Sliders")]
    public Slider musicSlider;
    public Slider sfxSlider;

    bool isPaused;

    void Start()
    {
        Time.timeScale = 1f;

        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

        // Music slider
        musicSlider.value = bgmSource.volume;
        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);

        // SFX slider
        if (sfxSources.Length > 0)
        {
            sfxSlider.value = sfxSources[0].volume;
        }

        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }

    // =========================
    // PAUSE
    // =========================

    public void PauseGame()
    {
        pausePanel.SetActive(true);

        pauseButton.SetActive(false);

        Time.timeScale = 0f;

        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);

        settingsPanel.SetActive(false);

        pauseButton.SetActive(true);

        Time.timeScale = 1f;

        isPaused = false;
    }

    // =========================
    // SETTINGS
    // =========================

    public void OpenSettings()
    {
        pausePanel.SetActive(false);

        settingsPanel.SetActive(true);
    }

    public void BackToPause()
    {
        settingsPanel.SetActive(false);

        pausePanel.SetActive(true);
    }

    // =========================
    // AUDIO
    // =========================

    public void ChangeMusicVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        foreach (AudioSource sfx in sfxSources)
        {
            sfx.volume = volume;
        }
    }

    // =========================
    // SCENES
    // =========================

    public void RestartGame()
    {
        Time.timeScale = 1f;

        MasterInfo.coinCount = 0;
        MasterInfo.gemCount = 0;
        MasterInfo.distanceRun = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        MasterInfo.coinCount = 0;
        MasterInfo.gemCount = 0;
        MasterInfo.distanceRun = 0;

        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}