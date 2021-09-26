using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterSystem : MonoBehaviour
{
    public GameObject character1, character2, character3;
    

    void Start()
    {
        character1.SetActive(true);
        character2.SetActive(false);
        character3.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            character1.SetActive(true);
            character2.SetActive(false);
            character3.SetActive(false);
        }

        if (Input.GetKeyDown("2"))
        {
            character1.SetActive(false);
            character2.SetActive(true);
            character3.SetActive(false);
        }

        if (Input.GetKeyDown("3"))
        {
            character1.SetActive(false);
            character2.SetActive(false);
            character3.SetActive(true);
        }
    }
}
