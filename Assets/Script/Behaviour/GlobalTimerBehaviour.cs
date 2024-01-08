using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class GlobalTimerBehaviour : MonoBehaviour
{
    public static GlobalTimerBehaviour instance;

    public Text timerText;
    public CanvasGroup cg;
    public Slider bar;
    private int _value;
    private int _valueMax;

    private void Awake()
    {
        instance = this;
    }

    public void Hide()
    {
        cg.alpha = 0;
    }

    public void Show()
    {
        cg.alpha = 1;
    }

    public void Init(int v)
    {
        _valueMax = v;
        SetValue(v);
    }
    public void SetValue(int v)
    {
        _value = v;
        timerText.text = v + "";

        if (bar != null)
        {
            SetBar(1f - (float)_value / _valueMax);
        }
    }

    public void Add(int v)
    {
        SetValue(_value + v);
    }

    public void SetBar(float v)
    {
        bar.value = v;
    }
}
