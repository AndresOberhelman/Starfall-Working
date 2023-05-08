using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 8f;
    // private float speedRecord = 8f;
    private bool isFacingRight = true;
    private Vector2 moveInput;

    
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;


    Animator animator;


    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        activeMoveSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Flip();

        moveInput.x = -Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        rb.velocity = moveInput * activeMoveSpeed;

        if(moveInput.magnitude > 0){
            AudioManager.Instance.PlayRun("Run");
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                AudioManager.Instance.PlaySFX("Dash");
            }
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if(dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }

        if(dashCoolCounter >0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    // private void FixedUpdate()
    // {


    //         rb.velocity = new Vector2(-horizontal * speed, vertical * speed);
    // }

    private void Flip()
    {
        if((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0);

            //Vector3 localScale = transform.localScale;
            //localScale.x *= -1f;
            //transform.localScale = localScale;


        }
        
        if(horizontal > 0f || horizontal < 0f)
        {
            animator.SetFloat("Speed", 1f);
            if(isFacingRight)
            {
                animator.SetFloat("XInput", 1f);
            }
            else
            {
                animator.SetFloat("XInput", -1f);
            }
        }
        else
        {
            animator.SetFloat("Speed", -1f);
            if(isFacingRight)
            {
                animator.SetFloat("XInput", 1f);
            }
            else
            {
                animator.SetFloat("XInput", -1f);
            }
        }


    }

    
}
