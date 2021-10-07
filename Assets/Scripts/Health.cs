using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthImage;

    public Animator camAnim;
    private float health;
 

    void Start()
    {
        Time.timeScale = 1;

        StartCoroutine(GetItems());
        
    }

    IEnumerator GetItems()
    {
        yield return new WaitForSeconds(0.5f);
        health = HealthMaster.Instance.health;
        healthImage.fillAmount = health;
    }

    void TakeDamage (float amount)
    {
        health = HealthMaster.Instance.health;
        HealthMaster.Instance.health -= amount;
        health = HealthMaster.Instance.health;
        healthImage.fillAmount = health;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!ShieldPower.instance2.IsActive)
        {

            if (other.tag == "agua")
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

            if (HealthMaster.Instance.health <= 0)
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
