using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using Text = TMPro.TextMeshProUGUI;

public class TextBehaviour : MonoBehaviour
{
    private Text _text;

    public Image img;

    public Color color_Default;
    public Color color_Important;
    public Color color_Alert;
    public Color color_Special;

    public bool instantShow;
    public float timePerCharacter = 0.2f;

    private float _timer;
    private bool _finished;
    private int _lastMaxCharacter;

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
        _finished = true;
        _lastMaxCharacter = 0;
    }

    public void Clear()
    {
        _text.text = "";
        _finished = true;
    }

    public void ShowText(string s)
    {
        Debug.Log("ShowText " + s);
        _text.text = s;
        if (instantShow)
        {
            _text.maxVisibleCharacters = 999;
            _finished = true;
            Finish();
        }
        else
        {
            _text.maxVisibleCharacters = 0;
            _lastMaxCharacter = 0;

            _timer = 0;
            _finished = false;
        }
    }

    void Update()
    {
        if (_finished)
            return;

        _timer += Time.deltaTime;
        int charCount = Mathf.FloorToInt(_timer / timePerCharacter);
        if (charCount != _lastMaxCharacter)
        {
            _text.maxVisibleCharacters = charCount;
            _lastMaxCharacter = charCount;
            if (_lastMaxCharacter >= _text.textInfo.characterCount)
            {
                _finished = true;
                Finish();
            }
        }
    }

    public void SetColor(BgColor bgColor)
    {
        switch (bgColor)
        {
            case BgColor.Default:
                img.color = color_Default;
                break;

            case BgColor.Important:
                img.color = color_Important;
                break;

            case BgColor.Alert:
                img.color = color_Alert;
                break;

            case BgColor.Special:
                img.color = color_Special;
                break;
        }
    }

    public System.Action OnFinished;

    public void Finish()
    {
        OnFinished?.Invoke();
        OnFinished = null;
    }
}
