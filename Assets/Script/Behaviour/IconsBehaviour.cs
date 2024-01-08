using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class IconsBehaviour : MonoBehaviour
{
    public static IconsBehaviour instance;

    public List<IconBehaviour> icons;
    public List<IconBehaviour> emotionKeys;

    private void Awake()
    {
        instance = this;
    }

    public void Clear()
    {
        foreach (var i in icons)
        {
            i.gameObject.SetActive(false);
        }

        foreach (var j in emotionKeys)
        {
            j.gameObject.SetActive(true);
        }
    }

    public void AddItem(string s)
    {
        foreach (var i in icons)
        {
            if (i.id == s)
            {
                i.gameObject.SetActive(true);
                i.transform.DOPunchScale(Vector3.one * 0.25f, 0.6f, 1, 1); 
            }
        }
    }

    public bool HasItem(string s)
    {
        foreach (var i in icons)
        {
            if (i.gameObject.activeSelf)
            {
                if (i.id == s)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
