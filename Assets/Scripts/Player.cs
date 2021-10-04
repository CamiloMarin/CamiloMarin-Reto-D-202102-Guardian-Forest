using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    

    // Variable para inicializar las animaciones
    private Animator anim;

    // Variable para el movimiento horizontal (vel de movimiento)
    public float runSpeed = 2;

    // Variable que se usa para establecer un valor de vel en el eje X

    public float dirX;

    // Variable para movimiento Vertical (vel de salto)
    public float jumpSpeed = 3;
 
    Rigidbody2D rB;
     
    // Layer donde se guarda 
    public LayerMask isLayerGround;

    // variable de la posicion del personaje (se utliza para hacer el raycast al suelo)
    public Transform groundPoint;
    public bool isGrounded; 

    private Vector2 InputVector;   

    // Esta variable se utiliza para saber a que direccion está yendo el personaje en el eje x
    private bool facingRight = true; 

    // Vector que se usa para saber cual es el valor de x en la escala del personaje (si es -1 - izquierda y si es 1 derecha)

    private Vector3 localScale;

    // Boolean para accionar la animacion de jump down o caida una sola vez

    public bool isFalling;

    // boolean para saber si se esta ejecutando la anim de saltar o de jump up

    private bool isJumping;

    public bool isFliping = false;

    public static Player instance;



    void Start()
    {
        instance = this;

        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    
    void Update()
    {
       

        dirX = Input.GetAxisRaw("Horizontal") * runSpeed;
        InputVector = new Vector2 (dirX, rB.velocity.y);
        rB.velocity = InputVector; 

     // El raycast sirve para detectar el suelo. 

            RaycastHit2D hit2D = Physics2D.Raycast(groundPoint.position , Vector2.down, 0.9f, isLayerGround);
            Debug.DrawRay(groundPoint.position , Vector2.down, Color.green,0.9f);

            // If the raycast hit something
            if (hit2D) 
            {
                isGrounded = true;
                
               
            }   else

            {
                isGrounded = false; 
                
            }


         // SALTO. Solo se salta si se está tocando el suelo con el raycast y tambien si se presiona la "W" 

        if(Input.GetKeyDown("w") && rB.velocity.y <= 0 && isGrounded)
        {
            rB.velocity += new Vector2(0f, jumpSpeed); 
            isJumping = true;
            isGrounded = false;
             

        }
        

        // Animacion de correr (Walk - run)

        if (Mathf.Abs(dirX) > 0 && rB.velocity.y == 0) 
        {
            anim.SetBool("isRunning", true);
        
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
       
        // Inicia la animación de salto hacia arriba
            if(rB.velocity.y > 0 && !isGrounded && isJumping)
            {
                 anim.SetBool("isJumping", true);
                 
            } 

        // Animación de salto hacia abajo

        if(rB.velocity.y < 0  && !isGrounded ) 
        {
           
            isJumping = false;
            anim.SetBool("isJumping", false); 
            anim.SetBool("isFalling", true);
            isFalling = true;
            
            
          

        } else if (rB.velocity.y == 0 && isGrounded)

            {
                anim.SetBool("isFalling", false);  
                isFalling = false;
                
            }

    }

    private void LateUpdate()
    {
        
        if (dirX > 0){
           
            facingRight = true;
        } else if (dirX < 0){
            facingRight = false;
        } 

       

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            
            flip();
            
        } 

        transform.localScale = localScale;

        
        
    }
   
   public void flip()
   {
        localScale.x *= -1;
        isFliping = true;
         
   } 

}
