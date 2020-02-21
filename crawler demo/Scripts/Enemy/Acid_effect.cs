using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid_effect : MonoBehaviour
{
    


    public void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }
    private void Update()
    {
        // move right 3m/s
        //deal with hit collision
        //destroy this after 5 secs

        transform.Translate(Vector3.right * 3 * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }

        }
    }
}