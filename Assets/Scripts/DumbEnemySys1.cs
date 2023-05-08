using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbEnemySys1 : MonoBehaviour
{
    //public static event Action<Enemy> OnEnemyKilled;
    public int health, maxHealth = 10;
    //public GameObject deathEffect;
    [SerializeField] float moveSpeed = 9f;
    // Start is called before the first frame update
    //Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;
    private Color originalColor;

    // private void Awake()
    // {
        
    // }

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        moveDirection = direction.normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
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
    