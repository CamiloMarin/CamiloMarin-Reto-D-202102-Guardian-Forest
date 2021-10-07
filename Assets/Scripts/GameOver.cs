using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //public GameObject GameOverText;
    //public GameObject tintosobj;
    public GameObject GameOverStatic;
    public GameObject tintos;
    public static GameOver Instance;

    // Use this for initialization
    void Start()
    {
        //tintos = tintosobj;
        //ameOverStatic = GameOverText;
        Instance = this;
        GameOverStatic.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void show()
    {
        tintos.SetActive(true);
        GameOverStatic.SetActive(true);
        

    }
    public void hide()
    {
        tintos.SetActive(false);
        GameOverStatic.SetActive(false);
    }
}
