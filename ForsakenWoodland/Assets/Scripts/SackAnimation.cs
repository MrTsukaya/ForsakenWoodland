using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SackAnimation : MonoBehaviour
{
    Image image;
    public GameObject txt;
    private void Start()
    {
        image = GetComponent<Image>();
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
