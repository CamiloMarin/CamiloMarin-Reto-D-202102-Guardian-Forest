using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBugs : MonoBehaviour
{
    [SerializeField] Sprite[] hitSprite;
    [SerializeField] int timesHit;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(tag == "bug")
        {
            HitHandle();
        }
    }

   void HitHandle ()
    {
        timesHit++;
        int maxHits = hitSprite.Length + 1;
        if (timesHit >= maxHits) { 
        Destroy(gameObject);
        }
        else
        {
            ShowNextSprite();
        }
    }

   void ShowNextSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprite[spriteIndex]!= null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        }
        else
        {
            Debug.Log("error, no se encontro el sprite");
        }
    }

    
}
