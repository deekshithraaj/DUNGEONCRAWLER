﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    // Start is called before the first frame update
    public int Health { get; set; }

   
    public override void Init()
    {
        base.Init();
        Health = base.health;

    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        if (isDead == true)
            return;
        //Debug.Log("Skeleton Damage!");

        Health--;
        _Eanim.SetTrigger("Hit");
        isHit = true;
        _Eanim.SetBool("InCombat",true);

        if (Health < 1)
        {
            isDead = true;
            _Eanim.SetTrigger("Death");
            //Destroy(this.gameObject);
            GameObject diamond = Instantiate(DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }

    }
   
}