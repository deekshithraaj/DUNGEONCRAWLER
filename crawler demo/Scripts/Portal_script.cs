using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_script : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 _portalSpawn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("portal collided");
            collision.gameObject.transform.position = _portalSpawn;
        }
    }
   void Start()
    {
        
         
        
         
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
