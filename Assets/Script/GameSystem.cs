using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour
{
    public PlotBehaviour plotBehaviour;

    public BlinkCanvasGroup bcg;

    public static GameSystem instance;
    public GameObject restartButton;
    public AudioSource mianBGM;
    public AudioSource writeBGM;
    public int score = 0;
    public bool fastMode;

    void Start()
    {
        instance = this;

        RestartGame();
    }

    public void RestartGame()
    {
        IconsBehaviour.instance.Clear();
        GlobalTimerBehaviour.instance.Hide();
        StartPlot(ConfigService.instance.startPlot);
        SetRestartButton(false);
        score = 0;
        ResetMusic();
    }

    public void StartPlot(Plot plot)
    {
        Debug.Log("StartPlot");
        plotBehaviour.Setup(plot);
    }

    public void SetRestartButton(bool show)
    {
        restartButton.SetActive(show);
    }

    public void ClearItems()
    {
        IconsBehaviour.instance.Clear();
    }

    public void ResetMusic()
    {
        mianBGM.enabled = true;
        writeBGM.enabled = false;
    }

    public void OverMusic()
    {
        mianBGM.enabled = false;
        writeBGM.enabled = true;
    }
}
