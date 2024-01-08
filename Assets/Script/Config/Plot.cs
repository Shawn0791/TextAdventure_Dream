using UnityEngine;
using System.Collections;

[System.Serializable]
[CreateAssetMenu]
public class Plot : ScriptableObject
{
    [Multiline]
    public string text;

    public Option optionLT;
    public Option optionRT;
    public Option optionLB;
    public Option optionRB;

    public string soundName;
    public string locationName;
    public BgColor color = BgColor.Default;
}

public enum BgColor
{
    Default,
    Important,
    Alert,
    Special,
}