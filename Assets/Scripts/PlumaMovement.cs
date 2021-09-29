using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumaMovement : MonoBehaviour
{
    private Rigidbody2D plumaRB;
    public float plumaSpeed;

    void Awake()
    {
        plumaRB = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        plumaRB.velocity = new Vector2(plumaSpeed, plumaRB.velocity.x);



    }

    // Update is called once per frame
    void Update()
    {

    }
}
