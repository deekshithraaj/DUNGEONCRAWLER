using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_script : MonoBehaviour
{
   

    public Vector2 _portalSpawn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("portal collided");
            collision.gameObject.transform.position = _portalSpawn;
        }
    }

}
