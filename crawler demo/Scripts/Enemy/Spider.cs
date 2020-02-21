using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamageable
{
   
   public int Health { get; set; }
   public GameObject acideffectPrefab;


    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public void Damage()
    {
        if (isDead == true)
            return;
        Health--;
        if (Health < 1)
        {
            isDead = true;
            _Eanim.SetTrigger("Death");
            GameObject diamond = Instantiate(DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }

    public override void Update()
    {
        
    }
    public override void Movement()
    {
    
    
    }
    public void Attack()
    {
        //instantiate acide effect
        Instantiate(acideffectPrefab, transform.position, Quaternion.identity);
    }
}
