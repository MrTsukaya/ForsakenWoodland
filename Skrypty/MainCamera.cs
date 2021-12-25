using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [Header("Ustawienia Kamery")]

    [SerializeField] private Vector3 distance;
    [SerializeField] private float lookUp;
    [SerializeField] private float lerpAmount;

    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //ustawia synchronizacje pionow� i klatki na 144
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 144;
    }
    void LateUpdate()
    {
        //przesuwa kamer� na pozycj� gracza + "distance", funkcja Lerp gwarantuje p�ynne przesuwanie
        transform.position = Vector3.Lerp(transform.position, player.transform.position + distance, lerpAmount * Time.deltaTime);      
    }
}
