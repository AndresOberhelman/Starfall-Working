using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRed : MonoBehaviour
{
    public int health, maxHealth = 70;
    
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Color flashColor = Color.yellow;
    public float flashDuration = 0.1f;
    private Color originalColor;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Dumb Damage!");
        Debug.Log("Dumb Health: " + health);
        originalColor = spriteRenderer.color;
        StartCoroutine(FlashRed());
        if(health <= 0)
        {
            Debug.Log("Dumb Should Die");
            Death();
        }
    }

    private IEnumerator FlashRed()
    {
    spriteRenderer.color = flashColor;
    yield return new WaitForSeconds(flashDuration);
    spriteRenderer.color = originalColor;
    }

    private void Death()
    {
        EnemyManager.enemiesDestroyed++;
        Destroy(gameObject);
    }
}
