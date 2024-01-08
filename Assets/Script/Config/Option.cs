using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu]
public class Option : ScriptableObject
{
    public string text;
    public Plot targetPlot;

    public string itemId;

    public BgColor color= BgColor.Default;

    public VFX vfx;//TODO
    public enum VFX
    {
        None,
        RedVignette,
        Fireworks,
        StartShowTimer,
        ShowRestartButton,
    }

    public TimerFeedback timerFeedback;//TODO
    public enum TimerFeedback
    {
        None,
        Set,
        Push,
    }
    public int timerFeedbackValue;

    public int score;

    public List<string> needItems;
}
