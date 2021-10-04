using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorroPowe : MonoBehaviour
{
    public Player player;
    public Rigidbody2D rb;
    public Animator anim;

    IEnumerator dashCoroutine;
    public float dashDuration = 0.1f; 
    public float dashCooldown = 5f;
    float direction = 1;
    float normalGravity;
    bool isDashing;
    bool canDash = true;
    bool animateDash;

    void Start() 
    {
        anim = GetComponent<Animator>();
        normalGravity = rb.gravityScale;
        
    }
    
    void Update() 
    {
        
        if(animateDash){
            anim.SetBool("isDashing", true);
        } else
        {
             anim.SetBool("isDashing", false);
        }

        if(player.dirX != 0)
        {
            direction = player.dirX;
        }
        
        if (Input.GetMouseButtonDown(0) && canDash == true)
        {
            
            if (dashCoroutine != null)
            {
                
                StopCoroutine(dashCoroutine);
            
            }
            
            dashCoroutine = Dash();
            StartCoroutine(dashCoroutine);


        } 

        if(isDashing)
        {
            
            animateDash = true;
            rb.AddForce(new Vector2(direction*6,0), ForceMode2D.Impulse);
            
        } else
        {   
            animateDash = false;
           
        }
        

    }
    
     
    void FixedUpdate() 
    {
        
    }
        
    IEnumerator Dash()
    {
        // 
        Vector2 orgiginalVelocity = rb.velocity;
        isDashing = true;
        canDash = false;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        SoundManager.Playsound("dash");
        yield return new WaitForSeconds(dashDuration);
        //
        
        isDashing = false;
        rb.gravityScale = normalGravity;
        rb.velocity = orgiginalVelocity;

        yield return new WaitForSeconds(dashCooldown);
        //
        canDash = true;
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnDisable()
    {
        StopAllCoroutines();
        
        canDash = true;

    }

}
