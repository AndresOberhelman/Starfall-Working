using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public int health;
    public int maxHealth=20;
    void Start()
    {
        health=maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

  
   public void TakeDamage(int amount)
   {
    health-=amount;
    healthBar.SetHealth(health);
    Debug.Log("Player taking damage");
    if(health <=0){
        Destroy(gameObject);
    }
   }
    public void ApplyDamage(int damageAmount) {
    TakeDamage(damageAmount);
    }
   
}
