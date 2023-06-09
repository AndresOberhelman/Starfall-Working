using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < 13){
          timer+=Time.deltaTime;  
        }
        
        if(timer >2){
            timer=0;
            shoot();
        }
    }

    void shoot(){
        AudioManager.Instance.PlaySFX("Shoot");
        Instantiate(bullet,bulletPos.position,Quaternion.identity);
    }
}
