using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SackAnimation : MonoBehaviour
{
    public static SackAnimation instance;
    Image image;
    public GameObject txt;
    void Start()
    {
        image = GetComponent<Image>();
    }
    void Awake()
    {
        if (SackAnimation.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void CoinIn()
    {
        int i = int.Parse(txt.GetComponent<Text>().text);
        i++;
        txt.GetComponent<Text>().text = i.ToString();
    }

    public void SackChange()
    {
        image.enabled = !image.enabled;
    }
}
