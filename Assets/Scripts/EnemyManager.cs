using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : LivingThings
{

    bool colliderBusy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !colliderBusy && !collision.GetComponent<PlayerController>().onAttack) {
            colliderBusy = true;
            collision.GetComponent<PlayerController>().GetDamageFromEnemy(damage);
        }
        else if(collision.tag == "Player" && collision.GetComponent<PlayerController>().onAttack)
        {
            colliderBusy = true;
            this.GetDamageFromEnemy(collision.GetComponent<PlayerController>().damage);
            Debug.Log("dkjfhjks");
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
          if (collision.tag == "Player" && collision.GetComponent<PlayerController>().onAttack)
        {
            colliderBusy = true;
            this.GetDamageFromEnemy(collision.GetComponent<PlayerController>().damage);
            Debug.Log("dkjfhjks");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            colliderBusy = false;
        }
      
    }
}
