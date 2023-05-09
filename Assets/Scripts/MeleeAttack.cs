using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
     public GameObject sword;
     public int damage = 3;
     public float attackRadius = 2f;
     public float attackDuration = 0.5f;

     private Camera mainCam;
     private Vector3 mousePos;
     private bool isAttacking;

     void Start()
     {
         mainCam = Camera.main;
     }

     void Update()
     {
         mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
         Vector3 direction = (mousePos - transform.position).normalized;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         sword.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

         if (Input.GetMouseButtonDown(0) && !isAttacking)
         {
             isAttacking = true;
             StartCoroutine(PerformAttack());
         }
     }

     IEnumerator PerformAttack()
     {
         //Play sword sweep animation
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        foreach (Collider2D hit in hits)
        {
        DumbEnemySys1 denemy = hit.GetComponent<DumbEnemySys1>();
        if(denemy != null)
        {
            denemy.TakeDamage(damage);
        } 
        DumbEnemyShooter denemyshoot = hit.GetComponent<DumbEnemyShooter>();
        if(denemyshoot != null)
        {
            denemyshoot.TakeDamage(damage);
        } 
        BossRed denemyboss = hit.GetComponent<BossRed>();
        if(denemyboss != null)
        {
            denemyboss.TakeDamage(damage);
        }
        



            // if (hit.gameObject.tag == "Enemy")
            // {
            //     hit.gameObject.GetComponent<DumbEnemySys1>().TakeDamage(damage);
            // }
        }

        yield return new WaitForSeconds(attackDuration);
        isAttacking = false;
     }

     void OnDrawGizmosSelected()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(transform.position, attackRadius);
     }
 }