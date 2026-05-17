using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinCondition : MonoBehaviour
{
    [Header("Win Settings")]
    public int coinsToWin = 50;

    [Header("UI")]
    public GameObject winPanel;

    public TMP_Text coinsCollectedText;
    public TMP_Text gemsCollectedText;

    [Header("Effects")]
    public GameObject confettiPrefab;

    public Transform player;

    bool hasWon = false;

    void Update()
    {
        if (!hasWon && MasterInfo.coinCount >= coinsToWin)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        hasWon = true;

        Time.timeScale = 0f;

        winPanel.SetActive(true);

        coinsCollectedText.text =
            "Coins: " + MasterInfo.coinCount;

        gemsCollectedText.text =
            "Gems: " + MasterInfo.gemCount;

        Instantiate(
            confettiPrefab,
            player.position + new Vector3(0, 5, 0),
            Quaternion.identity
        );
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        MasterInfo.coinCount = 0;
        MasterInfo.gemCount = 0;
        MasterInfo.distanceRun = 0;

        MainMenuControl.hasClicked = true;

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
}