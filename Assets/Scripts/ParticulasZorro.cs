using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasZorro : MonoBehaviour
{
   // Particulas de polvo

    public ParticleSystem Dust;

    public GameObject Zorro_GO;

    private Player player;

    void Start() {
        
        player = gameObject.GetComponent<Player>();     
    }

    private void Update() 
    {
        

        if(player.isGrounded == true && player.isFliping == true)
        {
            
            
                CreateDust();
                player.isFliping = false;
            
        }

    }

    void CreateDust()
    {
        Dust.Play();

    }
}
