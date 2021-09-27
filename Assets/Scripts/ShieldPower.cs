using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPower : MonoBehaviour
{
    public GameObject shield;
    private bool activateShield;
    private Animator anim;
    

    void Start()
    {
        activateShield = false;
        shield.SetActive(false);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (!activateShield)
            {
                anim.SetBool("ShieldActivate", true);
                shield.SetActive(true);
                activateShield = true;
                CharacterMovement.Instance.MoveSpeed = 0;
                CharacterMovement.Instance.JumpForce = 0;



            }

            else 
                
            {
                CharacterMovement.Instance.MoveSpeed = 5f;
                CharacterMovement.Instance.JumpForce = 650f ;
                shield.SetActive(false);
                activateShield = false;
                anim.SetBool("ShieldActivate", false);
            }
        }
    }

    public bool ActiveShield
    {
        get
        {
            return activateShield;
        }
        set
        {
            activateShield = value;
        }
    }
}
