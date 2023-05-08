using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBulletDriver : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody2D rb;
    public int BulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        DumbEnemySys1 denemy = hitInfo.GetComponent<DumbEnemySys1>();
        if(denemy != null)
        {
            denemy.TakeDamage(BulletDamage);
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    
}
