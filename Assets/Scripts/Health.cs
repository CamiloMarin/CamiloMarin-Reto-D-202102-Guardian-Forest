using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthImage;
  

    private ShieldPower shield;
    private float health;
    void Start()
    {
        Time.timeScale = 1;
        health = 1f;
        healthImage.fillAmount = health;    
        shield = this.GetComponent<ShieldPower>();
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
            }
            else if (other.tag == "lluvia")
            {
                TakeDamage(0.5f);
            }

            if (health <= 0)
            {
                Time.timeScale = 0;
                if (ExternLives.numOfTintos > 0)
                {
                    ExternLives.numOfTintos -= 1;
                }
                GameOver.Instance.show();
            }
        }

    }

    void Update()
    {
        
    }
}
