using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
  
    public int Health {get; set;}

    
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
        //Debug.Log(" Moss giantDamage!");

        Health--;
        _Eanim.SetTrigger("Hit");
        isHit = true;
        _Eanim.SetBool("InCombat", true);

        if (Health < 1)
        {
             isDead = true;
            _Eanim.SetTrigger("Death");
            GameObject diamond =Instantiate(DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }

    }
}
