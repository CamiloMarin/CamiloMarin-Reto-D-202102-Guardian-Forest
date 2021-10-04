using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthImage;

    public Animator camAnim;
    private ShieldPower shield;
    private float health;
    //public Collider2D ceiba;
    //public Collider2D zorro;
    //public Collider2D barranquero;

    void Start()
    {
        Time.timeScale = 1;
        health = 1f;
        healthImage.fillAmount = health;    
        shield = this.GetComponent<ShieldPower>();

        //ceiba.GetComponent<Collider2D>();
        //zorro.GetComponent<Collider2D>();
        //barranquero.GetComponent<Collider2D>();

        
    }

    void TakeDamage (float amount)
    {
        health -= amount;
        healthImage.fillAmount = health;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!shield.ActiveShield)
        {
            if(other.tag == "agua")
            {
                TakeDamage(1f);
                SoundManager.Playsound("damage");
               
            }
            else if (other.tag == "lluvia")
            {
                TakeDamage(0.3f);
                SoundManager.Playsound("damage");
                camAnim.SetTrigger("shake");
            }

            if (health <= 0)
            {
                Time.timeScale = 0;
                if (ExternLives.numOfTintos > 0)
                {
                    ExternLives.numOfTintos -= 1;
                }
                SoundManager.Playsound("dead");
                GameOver.Instance.show();
                
            }
        }

    }

    void Update()
    {
        
    }
}
