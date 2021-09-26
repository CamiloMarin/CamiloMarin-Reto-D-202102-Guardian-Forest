using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variable para el movimiento horizontal (vel de movimiento)
    public float runSpeed = 2;

    // Variable para movimiento Vertical (vel de salto)
    public float jumpSpeed = 3;
 
    Rigidbody rB;


    public LayerMask isLayerGround;
    public Transform groundPoint;
    private bool isGrounded; 

    private Vector3 InputVector;    

    void Start()
    {
       rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputVector = new Vector3 (Input.GetAxisRaw("Horizontal")*runSpeed, rB.velocity.y-2);
        rB.velocity = InputVector; 

        RaycastHit hit;
        
        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, 3f,isLayerGround))
        {
            isGrounded = true;
            Debug.Log("si");
        } else
        {
            isGrounded = false; 
            Debug.Log("No");
        }

        if(Input.GetKeyDown("w") && isGrounded)
        {
            rB.velocity += new Vector3(0f, jumpSpeed+2,0f);
        }

    }


   



}
