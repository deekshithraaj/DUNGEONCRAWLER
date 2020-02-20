using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpidyAnimationEvent : MonoBehaviour
{
    // Start is called before the first frame update


    private Spider _spider;

    private void Start()
    {
        _spider = transform.parent.GetComponent<Spider>();        
    }
    public void Fire()
    {
        //tell spider to fire
        //Debug.Log("Spider should fire");
        //use handle to attack method on spider
        _spider.Attack();
    }
}
