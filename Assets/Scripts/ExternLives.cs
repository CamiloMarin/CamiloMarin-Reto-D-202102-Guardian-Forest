using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExternLives : MonoBehaviour
{

    public int health;
    public static int numOfTintos = 3;
    public Image[] tintos;
    public Sprite fullTintos;
    public Sprite emptyTintos;
    public static ExternLives Instance;

    private void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if(health > numOfTintos)
        {
            health = numOfTintos;
        }

        for (int i = 0; i < tintos.Length; i++)
        {
            if(i <= health)
            {
                tintos[i].sprite = fullTintos;
            }
            else
            {
                tintos[i].sprite = emptyTintos;
            }
            if (i <= numOfTintos)
            {
                tintos[i].enabled = true;
            }
            else
            {
                tintos[i].enabled = false;
            }
        }
    }
}
