using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    //Damage structure
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    //Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //Swing
    private float cooldown = 0.5f;
    private float lastSwingTime;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    protected override void Update()
    {
        base.Update();
      if(Input.GetKeyDown(KeyCode.Space))
      {
        if (Time.time - lastSwingTime > cooldown)
        {
          lastSwingTime = Time.time;
          Swing();
        }
      }
    }


    protected override void OnCollide(Collider2D coll)
    {
       
    }

    private void Swing()
    {
      Debug.Log("Swing");
    }
  
}
