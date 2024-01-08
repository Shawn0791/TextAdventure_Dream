using UnityEngine;
using System;
using DG.Tweening;
using Text = TMPro.TextMeshProUGUI;

public class PlotBehaviour : MonoBehaviour
{
    public TextBehaviour tb;
    public Text locationText;
    public Text scoreText;

    public OptionBehaviour optionLT;
    public OptionBehaviour optionRT;
    public OptionBehaviour optionLB;
    public OptionBehaviour optionRB;

    public RectTransform plotTrans;

    private Plot _plot;
    public string defaultSoundName;

    public void Setup(Plot plot)
    {
        Debug.Log(plot);
        scoreText.text = GameSystem.instance.score + "";
        if (ConfigService.instance.startPlot== plot)
        {
            GameSystem.instance.ClearItems();
        }

        tb.Clear();
        optionLT.Setup(null);
        optionRT.Setup(null);
        optionLB.Setup(null);
        optionRB.Setup(null);

        if (_plot != null)
        {
            ShowAnimOut(ShowAnimIn);
            _plot = plot;
        }
        else
        {
            _plot = plot;
            ShowAnimIn();
        }
        if (GameSystem.instance.fastMode)
        {
            optionLT.Setup(_plot.optionLT);
            optionRT.Setup(_plot.optionRT);
            optionLB.Setup(_plot.optionLB);
            optionRB.Setup(_plot.optionRB);

            optionLT.ShowAnimIn();
            optionRT.ShowAnimIn();
            optionLB.ShowAnimIn();
            optionRB.ShowAnimIn();
        }
        SoundService.instance.Play(_plot.soundName == "" ? defaultSoundName : _plot.soundName);
    }

    public Vector2 inPos;
    public Vector2 outPos;
    public Vector2 finalPos = Vector2.zero;

    public void ShowAnimIn()
    {
        //Debug.Log("ShowAnimIn");
        plotTrans.anchoredPosition = inPos;
        plotTrans.DOAnchorPos(finalPos, 0.6f).SetEase(Ease.OutCubic).OnComplete(ShowContent);
    }

    public void ShowAnimOut(Action next)
    {
        //Debug.Log("ShowAnimOut");
        plotTrans.anchoredPosition = finalPos;
        plotTrans.DOAnchorPos(outPos, 0.6f).SetEase(Ease.InBack).OnComplete(() => { next?.Invoke(); });
    }

    void ShowContent()
    {
        //Debug.Log("ShowContent");
        if (_plot == null)
            return;

        tb.ShowText(_plot.text);
        tb.SetColor(_plot.color);
      
        locationText.text = _plot.locationName;
        if (GameSystem.instance.fastMode)
        {
            return;
        }
        tb.OnFinished = () =>
        {
            optionLT.Setup(_plot.optionLT);
            optionRT.Setup(_plot.optionRT);
            optionLB.Setup(_plot.optionLB);
            optionRB.Setup(_plot.optionRB);

            optionLT.ShowAnimIn();
            optionRT.ShowAnimIn();
            optionLB.ShowAnimIn();
            optionRB.ShowAnimIn();
        };
    }
}
