using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    protected override void OnCollect()
    {
        base.OnCollect();
        GameManager.instance.gold += 1;
        Destroy(gameObject);
    }
}
