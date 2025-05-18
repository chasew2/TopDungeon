using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int coinsAmt = 5;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.coins += coinsAmt;
            GameManager.instance.ShowText("+" + coinsAmt + "coins!", 20, Color.yellow, transform.position, Vector3.up * 50, 1f);
            
        }
    }
}
