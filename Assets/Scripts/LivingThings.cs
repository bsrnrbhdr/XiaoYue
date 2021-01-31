using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingThings : MonoBehaviour
{
    public float health;
    bool dead = false;
    public float damage;
    bool facingRight = true;

    public void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    public void GetDamageFromEnemy(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        Dead();
    }

    public bool getFacingRight()
    {
        return this.facingRight;
    }
    public void setFacingRight(bool facingRight)
    {
        this.facingRight = facingRight;
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
    void Dead()
    {
        if (this.health <= 0)
        {
            this.dead = true;
        }
    }

}
