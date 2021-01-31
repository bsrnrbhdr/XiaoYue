using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float health;
    private bool dead = false;
    private float damage;
  
    public void GetDamage(float damage)
    {
        if((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        Dead();
    }

    void Dead()
    {
        if(health <= 0)
        {
            dead = true;
        }
    }
    public float getHealth()
    {
        return this.health;
    }
    public void setHealth(float health)
    {
        this.health = health;
    }
    public float getDamage()
    {
        return this.damage;
    }
    public void setDamage(float damage)
    {
        this.damage = damage;
    }
    public bool getAlive()
    {
        return this.dead;
    }
  
}


