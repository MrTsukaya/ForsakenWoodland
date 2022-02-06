using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSwitch : MonoBehaviour
{
    [Header("Rooms Teleport settings")]
    [SerializeField] public float x_position;
    [SerializeField] public float y_position;

    Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = new Vector2(x_position, y_position);
    }
}
