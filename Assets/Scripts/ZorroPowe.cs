using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorroPowe : MonoBehaviour
{

  

    void Start()
    {
       

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CharacterMovement2.Instance2.JumpForce2 = 800f;
            
            StartCoroutine(WaitBeforDesactivate());
        }

        
    }
     IEnumerator WaitBeforDesactivate()
    {
        yield return new WaitForSeconds(2);
        
        CharacterMovement2.Instance2.JumpForce2 = 650f;
    }


}
