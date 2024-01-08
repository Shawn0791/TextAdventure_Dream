using UnityEngine;
using System.Collections;

public class ConfigService : MonoBehaviour
{
    public static ConfigService instance;

    public Plot startPlot;

    private void Awake()
    {
        instance = this;
    }
}
