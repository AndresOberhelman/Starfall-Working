using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    public Rigidbody2D rb;
    public float force;
    public int BulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rot+90);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        DumbEnemySys1 denemy = hitInfo.GetComponent<DumbEnemySys1>();
        if(denemy != null)
        {
            denemy.TakeDamage(BulletDamage);
        }
        gameObject.SetActive(false);

        DumbEnemyShooter denemyshoot = hitInfo.GetComponent<DumbEnemyShooter>();
        if(denemyshoot != null)
        {
            denemyshoot.TakeDamage(BulletDamage);
        }
        gameObject.SetActive(false); 
        BossRed denemyboss = hitInfo.GetComponent<BossRed>();
        if(denemyboss != null)
        {
            denemyboss.TakeDamage(BulletDamage);
        }
        gameObject.SetActive(false);
    }

   
    

}
