using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionControler : MonoBehaviour
{
    public GameObject emotionKey;

    private void OnEnable()
    {
        if(emotionKey.activeSelf == true)
            emotionKey.SetActive(false);
        if (emotionKey.GetComponent<IconBehaviour>().id == "3")
            GameSystem.instance.OverMusic();

    }
    void Update()
    {
        //if (gameObject.activeSelf == true && emotionKey.activeSelf == true) 
        //    emotionKey.SetActive(false);
    }
}
