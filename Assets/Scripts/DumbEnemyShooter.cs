using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbEnemyShooter : MonoBehaviour
{
    //public static event Action<Enemy> OnEnemyKilled;
    public int health, maxHealth = 10;
    //public GameObject deathEffect;
    [SerializeField] float moveSpeed = 9f;
    // Start is called before the first frame update
    //Rigidbody2D rb;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Color flashColor = Color.yellow;
    public float flashDuration = 0.1f;
    private Color originalColor;

private IEnumerator FlashRed()
    {
    spriteRenderer.color = flashColor;
    yield return new WaitForSeconds(flashDuration);
    spriteRenderer.color = originalColor;
    }

    void Start()
    {
         health = maxHealth;
    }

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

    

    private void Death()
    {
        EnemyManager.enemiesDestroyed++;
        Destroy(gameObject);
    }
}
